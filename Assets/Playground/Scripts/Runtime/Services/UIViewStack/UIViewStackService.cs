using Juce.Core.Repositories;
using Juce.Core.Sequencing;
using Juce.CoreUnity.UI;
using System;

namespace Playground.Services.ViewStack
{
    public class UIViewStackService : IUIViewStackService
    {
        private readonly UIViewRepository registeredViewsRepository = new UIViewRepository();
        private readonly UIInteractorRepository registeredInteractorsRepository = new UIInteractorRepository();
        private readonly IKeyValueRepository<Type, IUIInteractor> interactorsRepository = new SimpleKeyValueRepository<Type, IUIInteractor>();
        private readonly ViewContexRepository viewContexRepository = new ViewContexRepository();
        private readonly ViewQueueRepository viewQueueRepository = new ViewQueueRepository();

        private readonly Sequencer sequencer = new Sequencer();

        public void Init()
        {
            
        }

        public void CleanUp()
        {
           
        }

        public void Register<T>(T uiInteractor, UIView uiView) where T : IUIInteractor
        {
            registeredInteractorsRepository.Add(uiView, uiInteractor);
            interactorsRepository.Add(typeof(T), uiInteractor);
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

        public TInteractor GetInteractor<TInteractor>() where TInteractor : IUIInteractor
        {
            interactorsRepository.TryGet(typeof(TInteractor), out IUIInteractor interactor);

            return (TInteractor)interactor;
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
