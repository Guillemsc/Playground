using Juce.Core.Sequencing;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.UI;
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
