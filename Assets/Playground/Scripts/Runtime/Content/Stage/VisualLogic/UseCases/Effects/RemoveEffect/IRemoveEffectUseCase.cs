using Juce.Core.Disposables;
using Playground.Content.Stage.VisualLogic.Effects;

namespace Playground.Content.Stage.VisualLogic.UseCases.RemoveEffect
{
    public interface IRemoveEffectUseCase
    {
        void Execute(IDisposable<EffectWithTriggerExpirator> creation);
    }
}
