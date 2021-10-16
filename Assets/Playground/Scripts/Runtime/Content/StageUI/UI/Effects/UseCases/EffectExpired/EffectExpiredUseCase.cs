using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Juce.CoreUnity.Layout;
using Playground.Content.Stage.VisualLogic.Effects;
using Playground.Content.StageUI.UI.Effects.Entries;
using Playground.Content.StageUI.UI.Effects.UseCases.DespawnEffectEntry;

namespace Playground.Content.StageUI.UI.Effects.UseCases.EffectExpired
{
    public class EffectExpiredUseCase : IEffectExpiredUseCase
    {
        private readonly ManualHorizontalLayout manualHorizontalLayout;
        private readonly IKeyValueRepository<EffectWithTriggerExpirator, IDisposable<EffectUIEntry>> triggerEntryRepository;
        private readonly IDespawnEffectEntryUseCase despawnEffectEntryUseCase;

        public EffectExpiredUseCase(
            ManualHorizontalLayout manualHorizontalLayout,
            IKeyValueRepository<EffectWithTriggerExpirator, IDisposable<EffectUIEntry>> triggerEntryRepository,
            IDespawnEffectEntryUseCase despawnEffectEntryUseCase
            )
        {
            this.manualHorizontalLayout = manualHorizontalLayout;
            this.triggerEntryRepository = triggerEntryRepository;
            this.despawnEffectEntryUseCase = despawnEffectEntryUseCase;
        }

        public void Execute(EffectWithTriggerExpirator effectWithTriggerExpirator)
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

            despawnEffectEntryUseCase.Execute(entry);

            manualHorizontalLayout.Refresh();
        }
    }
}
