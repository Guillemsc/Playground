using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Playground.Content.Stage.VisualLogic.Effects;

namespace Playground.Content.Stage.VisualLogic.UseCases.RemoveEffect
{
    public class RemoveEffectUseCase : IRemoveEffectUseCase
    {
        private readonly IRepository<IDisposable<EffectWithTriggerExpirator>> effectsRepository;

        public RemoveEffectUseCase(
            IRepository<IDisposable<EffectWithTriggerExpirator>> effectsRepository
            )
        {
            this.effectsRepository = effectsRepository;
        }

        public void Execute(IDisposable<EffectWithTriggerExpirator> creation)
        {
            effectsRepository.Remove(creation);

            creation.Dispose();
        }
    }
}
