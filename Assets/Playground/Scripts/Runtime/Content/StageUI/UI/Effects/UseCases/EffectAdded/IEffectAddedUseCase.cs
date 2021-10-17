using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Effects;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.StageUI.UI.Effects.UseCases.EffectAdded
{
    public interface IEffectAddedUseCase
    {
        void Execute(
            EffectEntityView effectEntityView,
            EffectWithTriggerExpirator effectWithTriggerExpirator
            );
    }
}
