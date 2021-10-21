using Juce.Core.Subscribables;
using Playground.Content.Stage.VisualLogic.Effects;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.StageUI.UI.Effects.UseCases.EffectAdded;
using Playground.Content.StageUI.UI.Effects.UseCases.EffectExpired;

namespace Playground.Content.StageUI.UI.Effects
{
    public class EffectsUIInteractor : IEffectsUIInteractor, ISubscribable
    {
        private readonly EffectsUIViewModel viewModel;
        private readonly IEffectAddedUseCase effectAddedUseCase;
        private readonly IEffectExpiredUseCase effectExpiredUseCase;

        public EffectsUIInteractor(
            EffectsUIViewModel viewModel,
            IEffectAddedUseCase effectAddedUseCase,
            IEffectExpiredUseCase effectExpiredUseCase
            )
        {
            this.viewModel = viewModel;
            this.effectAddedUseCase = effectAddedUseCase;
            this.effectExpiredUseCase = effectExpiredUseCase;
        }

        public void Subscribe()
        {

        }

        public void Unsubscribe()
        {

        }

        public void AddEffect(
            EffectEntityView effectEntityView, 
            EffectWithTriggerExpirator effectWithTriggerExpirator
            )
        {
            effectAddedUseCase.Execute(effectEntityView, effectWithTriggerExpirator);
        }

        public void ExpireEffect(EffectWithTriggerExpirator effectWithTriggerExpirator)
        {
            effectExpiredUseCase.Execute(effectWithTriggerExpirator);
        }
    }
}
