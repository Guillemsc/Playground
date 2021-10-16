using Juce.Core.Subscribables;
using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Effects;
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

        public void Refresh()
        {
          
        }

        public void AddEffect(
            EffectConfiguration effectConfiguration, 
            EffectWithTriggerExpirator effectWithTriggerExpirator
            )
        {
            effectAddedUseCase.Execute(effectConfiguration, effectWithTriggerExpirator);
        }

        public void ExpireEffect(EffectWithTriggerExpirator effectWithTriggerExpirator)
        {
            effectExpiredUseCase.Execute(effectWithTriggerExpirator);
        }
    }
}
