using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Effects;

namespace Playground.Content.StageUI.UI.Effects.UseCases.EffectAdded
{
    public interface IEffectAddedUseCase
    {
        void Execute(
            EffectConfiguration effectConfiguration,
            EffectWithTriggerExpirator effectWithTriggerExpirator
            );
    }
}
