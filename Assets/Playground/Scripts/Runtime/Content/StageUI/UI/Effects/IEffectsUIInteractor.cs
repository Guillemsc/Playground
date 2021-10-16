using Juce.CoreUnity.UI;
using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Effects;

namespace Playground.Content.StageUI.UI.Effects
{
    public interface IEffectsUIInteractor : UIInteractor
    {
        void AddEffect(
            EffectConfiguration effectConfiguration,
            EffectWithTriggerExpirator effectWithTriggerExpirator
            );

        void ExpireEffect(EffectWithTriggerExpirator effectWithTriggerExpirator);
    }
}
