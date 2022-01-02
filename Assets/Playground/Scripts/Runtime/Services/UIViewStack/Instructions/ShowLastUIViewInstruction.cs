using Juce.Core.Sequencing;
using Juce.CoreUnity.UI;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Services.ViewStack
{
    public class ShowLastUIViewInstruction : Instruction
    {
        private readonly UIViewRepository registeredViewsRepository;
        private readonly ViewContexRepository viewContexRepository;
        private readonly ViewQueueRepository viewQueueRepository;
        private readonly UIInteractorRepository uiInteractorRepository;

        private readonly bool behindForeground;
        private readonly bool instantly;

        public ShowLastUIViewInstruction(
            UIViewRepository registeredViewsRepository,
            ViewContexRepository viewContexRepository,
            ViewQueueRepository viewQueueRepository,
            UIInteractorRepository uiInteractorRepository,
            bool behindForeground,
            bool instantly
            )
        {
            this.registeredViewsRepository = registeredViewsRepository;
            this.viewContexRepository = viewContexRepository;
            this.viewQueueRepository = viewQueueRepository;
            this.uiInteractorRepository = uiInteractorRepository;
            this.behindForeground = behindForeground;
            this.instantly = instantly;
        }

        protected override Task OnExecute(CancellationToken cancellationToken)
        {
            Type viewType = viewQueueRepository.Peek();
            viewQueueRepository.Pop();

            bool found = registeredViewsRepository.TryGet(viewType, out UIView uiView);

            if (!found)
            {
                UnityEngine.Debug.LogError($"Tried to Show {nameof(UIView)} of type {viewType.Name}, " +
                    $"but it was not registered, at {nameof(ShowLastUIViewInstruction)}");

                return Task.CompletedTask;
            }

            viewContexRepository.Add(new ViewContex(uiView));

            if (behindForeground)
            {
                UIFrame.Instance.PushBehindForeground(uiView);
            }
            else
            {
                UIFrame.Instance.PushForeground(uiView);
            }

            bool interactorFound = uiInteractorRepository.TryGet(viewType, out IUIInteractor interactor);

            if (interactorFound)
            {
                interactor.Refresh();
            }

            return uiView.Show(instantly, cancellationToken);
        }
    }
}
