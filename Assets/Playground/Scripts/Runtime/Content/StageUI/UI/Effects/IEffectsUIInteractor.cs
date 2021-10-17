using Juce.CoreUnity.UI;
using Playground.Content.Stage.VisualLogic.Effects;
using Playground.Content.Stage.VisualLogic.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.StageUI.UI.Effects
{
    public interface IEffectsUIInteractor : UIInteractor
    {
        void AddEffect(
            EffectEntityView effectEntityView,
            EffectWithTriggerExpirator effectWithTriggerExpirator
            );

        void ExpireEffect(EffectWithTriggerExpirator effectWithTriggerExpirator);
    }
}
