using Juce.Core.Sequencing;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.UI;
using System;
using UnityEngine;

namespace Playground.Services.ViewStack
{
    public class UIViewStackService : IService
    {
        private readonly UIViewRepository registeredViewsRepository = new UIViewRepository();
        private readonly UIInteractorRepository registeredInteractorsRepository = new UIInteractorRepository();
        private readonly ViewContexRepository viewContexRepository = new ViewContexRepository();
        private readonly ViewQueueRepository viewQueueRepository = new ViewQueueRepository();

        private readonly Sequencer sequencer = new Sequencer();

        private readonly Canvas canvas;

        public Canvas Canvas => canvas;

        public UIViewStackService(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void Init()
        {
            
        }

        public void CleanUp()
        {
           
        }

        public void Register(UIInteractor uiInteractor, UIView uiView)
        {
            registeredInteractorsRepository.Add(uiView, uiInteractor);
            registeredViewsRepository.Add(uiView);

            UIFrame.Instance.Register(uiView);
        }

        public void Unregister(UIView uiView)
        {
            registeredInteractorsRepository.Remove(uiView);
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
            bool found = registeredInteractorsRepository.TryGet<T>(out UIInteractor uiInteractor);

            if (!found)
            {
                UnityEngine.Debug.LogError($"Tried to get {nameof(UIInteractor)} for view of type {typeof(T).Name}, " +
                    $"but it was not registered, at {nameof(UIViewStackService)}");
                return default;
            }

            return (T)uiInteractor;
        }

        public ViewStackSequence New()
        {
            return new ViewStackSequence(
                registeredViewsRepository, 
                viewContexRepository,
                viewQueueRepository,
                registeredInteractorsRepository,
                sequencer
                );
        }
    }
}
