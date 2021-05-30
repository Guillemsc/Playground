using Juce.CoreUnity.Service;
using Juce.CoreUnity.UI;

namespace Playground.Services.ViewStack
{
    public class UIViewStackService : IService
    {
        private readonly RegisteredViewsRepository registeredViewsRepository = new RegisteredViewsRepository();
        private readonly ViewContexRepository viewContexRepository = new ViewContexRepository();

        public void Init()
        {
            
        }

        public void CleanUp()
        {
           
        }

        public void Register(UIView uiView)
        {
            UIFrame.Instance.Register(uiView);
            registeredViewsRepository.Add(uiView);
        }

        public void Unregister(UIView uiView)
        {
            registeredViewsRepository.Remove(uiView);
        }

        public ViewStackSequence New()
        {
            return new ViewStackSequence(registeredViewsRepository, viewContexRepository);
        }
    }
}
