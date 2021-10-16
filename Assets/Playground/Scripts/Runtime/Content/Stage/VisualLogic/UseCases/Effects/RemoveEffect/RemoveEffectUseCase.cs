using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Playground.Content.Stage.VisualLogic.Effects;
using Playground.Content.StageUI.UI.Effects;

namespace Playground.Content.Stage.VisualLogic.UseCases.RemoveEffect
{
    public class RemoveEffectUseCase : IRemoveEffectUseCase
    {
        private readonly IRepository<IDisposable<EffectWithTriggerExpirator>> effectsRepository;
        private readonly IEffectsUIInteractor effectsUIInteractor;

        public RemoveEffectUseCase(
            IRepository<IDisposable<EffectWithTriggerExpirator>> effectsRepository,
            IEffectsUIInteractor effectsUIInteractor
            )
        {
            this.effectsRepository = effectsRepository;
            this.effectsUIInteractor = effectsUIInteractor;
        }

        public void Execute(IDisposable<EffectWithTriggerExpirator> creation)
        {
            effectsRepository.Remove(creation);

            creation.Dispose();

            effectsUIInteractor.ExpireEffect(creation.Value);
        }
    }
}
