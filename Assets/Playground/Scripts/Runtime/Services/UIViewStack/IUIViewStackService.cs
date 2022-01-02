using Juce.CoreUnity.UI;

namespace Playground.Services.ViewStack
{
    public interface IUIViewStackService
    {
        void Register<T>(T uiInteractor, UIView uiView) where T : IUIInteractor;
        void Unregister(UIView uiView);
        TInteractor GetInteractor<TInteractor>() where TInteractor : IUIInteractor;

        ViewStackSequence New();
    }
}
