using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Juce.Core.Sequencing;
using Juce.CoreUnity.Layout;
using Playground.Content.Stage.VisualLogic.Effects;
using Playground.Content.StageUI.UI.Effects.Entries;
using Playground.Content.StageUI.UI.Effects.UseCases.DespawnEffectEntry;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.StageUI.UI.Effects.UseCases.EffectExpired
{
    public class EffectExpiredUseCase : IEffectExpiredUseCase
    {
        private readonly ISequencer sequencer;
        private readonly ManualHorizontalLayout manualHorizontalLayout;
        private readonly IKeyValueRepository<EffectWithTriggerExpirator, IDisposable<EffectUIEntry>> triggerEntryRepository;
        private readonly IDespawnEffectEntryUseCase despawnEffectEntryUseCase;

        public EffectExpiredUseCase(
            ISequencer sequencer,
            ManualHorizontalLayout manualHorizontalLayout,
            IKeyValueRepository<EffectWithTriggerExpirator, IDisposable<EffectUIEntry>> triggerEntryRepository,
            IDespawnEffectEntryUseCase despawnEffectEntryUseCase
            )
        {
            this.sequencer = sequencer;
            this.manualHorizontalLayout = manualHorizontalLayout;
            this.triggerEntryRepository = triggerEntryRepository;
            this.despawnEffectEntryUseCase = despawnEffectEntryUseCase;
        }

        public void Execute(EffectWithTriggerExpirator effectWithTriggerExpirator)
        {
            sequencer.Play((ct) => Run(effectWithTriggerExpirator, ct));
        }

        public async Task Run(EffectWithTriggerExpirator effectWithTriggerExpirator, CancellationToken cancellationToken)
        {
            bool found = triggerEntryRepository.TryGet(
                effectWithTriggerExpirator,
                out IDisposable<EffectUIEntry> entry
                );

            if(!found)
            {
                return;
            }

            triggerEntryRepository.Remove(effectWithTriggerExpirator);

            await entry.Value.SetVisible(visible: false, instantly: false, cancellationToken);

            despawnEffectEntryUseCase.Execute(entry);

            manualHorizontalLayout?.Refresh();
        }
    }
}
