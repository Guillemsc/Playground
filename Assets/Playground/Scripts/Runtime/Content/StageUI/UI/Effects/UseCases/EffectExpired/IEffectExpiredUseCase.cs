using Playground.Content.Stage.VisualLogic.Effects;

namespace Playground.Content.StageUI.UI.Effects.UseCases.EffectExpired
{
    public interface IEffectExpiredUseCase
    {
        void Execute(EffectWithTriggerExpirator effectWithTriggerExpirator);
    }
}
