using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Juce.CoreUnity.Layout;
using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Effects;
using Playground.Content.StageUI.UI.Effects.Entries;
using Playground.Content.StageUI.UI.Effects.UseCases.TrySpawnEffectEntry;

namespace Playground.Content.StageUI.UI.Effects.UseCases.EffectAdded
{
    public class EffectAddedUseCase : IEffectAddedUseCase
    {
        private readonly ManualHorizontalLayout manualHorizontalLayout;
        private readonly IKeyValueRepository<EffectWithTriggerExpirator, IDisposable<EffectUIEntry>> triggerEntryRepository;
        private readonly ITrySpawnEffectEntryUseCase trySpawnEffectEntryUseCase;

        public EffectAddedUseCase(
            ManualHorizontalLayout manualHorizontalLayout,
            IKeyValueRepository<EffectWithTriggerExpirator, IDisposable<EffectUIEntry>> triggerEntryRepository,
            ITrySpawnEffectEntryUseCase trySpawnEffectEntryUseCase
            )
        {
            this.manualHorizontalLayout = manualHorizontalLayout;
            this.triggerEntryRepository = triggerEntryRepository;
            this.trySpawnEffectEntryUseCase = trySpawnEffectEntryUseCase;
        }

        public void Execute(
            EffectConfiguration effectConfiguration,
            EffectWithTriggerExpirator effectWithTriggerExpirator
            )
        {
            bool spawned = trySpawnEffectEntryUseCase.Execute(out IDisposable<EffectUIEntry> result);

            if(!spawned)
            {
                return;
            }

            triggerEntryRepository.Add(effectWithTriggerExpirator, result);

            manualHorizontalLayout.AddAndRefresh(result.Value.transform);
        }
    }
}
