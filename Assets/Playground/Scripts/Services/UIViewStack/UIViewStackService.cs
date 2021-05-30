using Juce.CoreUnity.Service;
using Juce.CoreUnity.UI;
using System;

namespace Playground.Services.ViewStack
{
    public class UIViewStackService : IService
    {
        private readonly UIViewRepository registeredViewsRepository = new UIViewRepository();
        private readonly UIInteractorRepository registeredInteractorsRepository = new UIInteractorRepository();
        private readonly ViewContexRepository viewContexRepository = new ViewContexRepository();

        public void Init()
        {
            
        }

        public void CleanUp()
        {
           
        }

        public void Register(UIInteractor uiInteractor, UIView uiView)
        {
            registeredInteractorsRepository.Add(uiInteractor);
            registeredViewsRepository.Add(uiView);

            UIFrame.Instance.Register(uiView);
        }

        public void Unregister(UIInteractor uiInteractor, UIView uiView)
        {
            registeredInteractorsRepository.Remove(uiInteractor);
            registeredViewsRepository.Remove(uiView);

            if(uiView.IsPopup)
            {
                bool found = viewContexRepository.TryGetPopup(uiView, out ViewContex viewContext);

                if(found)
                {
                    viewContext.PopupUIViews.Remove(uiView);
                }
            }
            else
            {
                bool found = viewContexRepository.TryGet(uiView, out ViewContex viewContext);

                if (found)
                {
                    viewContexRepository.Remove(viewContext);
                }
            }
        }

        public T GetInteractor<T>() where T : UIInteractor
        {
            Type type = typeof(T);
            bool found = registeredInteractorsRepository.TryGet(type, out UIInteractor uiInteractor);

            if(!found)
            {
                UnityEngine.Debug.LogError($"Tried to get {nameof(UIInteractor)} of type {type.Name}, " +
                    $"but it was not registered, at {nameof(UIViewStackService)}");
                return default;
            }

            return (T)uiInteractor;
        }

        public ViewStackSequence New()
        {
            return new ViewStackSequence(registeredViewsRepository, viewContexRepository);
        }
    }
}
