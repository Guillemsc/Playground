using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Juce.Core.Sequencing;
using Juce.CoreUnity.Layout;
using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Effects;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.StageUI.UI.Effects.Entries;
using Playground.Content.StageUI.UI.Effects.Factories;
using Playground.Content.StageUI.UI.Effects.UseCases.TrySpawnEffectEntry;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.StageUI.UI.Effects.UseCases.EffectAdded
{
    public class EffectAddedUseCase : IEffectAddedUseCase
    {
        private readonly ISequencer sequencer;
        private readonly ManualHorizontalLayout manualHorizontalLayout;
        private readonly IKeyValueRepository<EffectWithTriggerExpirator, IDisposable<EffectUIEntry>> triggerEntryRepository;
        private readonly ITrySpawnEffectEntryUseCase trySpawnEffectEntryUseCase;

        public EffectAddedUseCase(
            ISequencer sequencer,
            ManualHorizontalLayout manualHorizontalLayout,
            IKeyValueRepository<EffectWithTriggerExpirator, IDisposable<EffectUIEntry>> triggerEntryRepository,
            ITrySpawnEffectEntryUseCase trySpawnEffectEntryUseCase
            )
        {
            this.sequencer = sequencer;
            this.manualHorizontalLayout = manualHorizontalLayout;
            this.triggerEntryRepository = triggerEntryRepository;
            this.trySpawnEffectEntryUseCase = trySpawnEffectEntryUseCase;
        }

        public void Execute(
            EffectEntityView effectEntityView,
            EffectWithTriggerExpirator effectWithTriggerExpirator
            )
        {
            sequencer.Play((ct) => Run(effectEntityView, effectWithTriggerExpirator, ct));
        }

        public async Task Run(
            EffectEntityView effectEntityView,
            EffectWithTriggerExpirator effectWithTriggerExpirator,
            CancellationToken cancellationToken
            )
        {
            EffectUIEntryFactoryDefinition definition = new EffectUIEntryFactoryDefinition(
               effectEntityView.Background.sprite,
               effectEntityView.Icon.sprite
               );

            bool spawned = trySpawnEffectEntryUseCase.Execute(
                definition,
                out IDisposable<EffectUIEntry> result
                );

            if (!spawned)
            {
                return;
            }

            triggerEntryRepository.Add(effectWithTriggerExpirator, result);

            await result.Value.SetVisible(visible: false, instantly: true, cancellationToken);

            manualHorizontalLayout.AddAndRefresh(result.Value.transform);

            await result.Value.SetVisible(visible: true, instantly: false, cancellationToken);
        }
    }
}
