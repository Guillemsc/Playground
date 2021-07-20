using Juce.Core.Sequencing;
using Juce.CoreUnity.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Services.ViewStack
{
    public class HideUIViewInstruction : Instruction
    {
        private readonly UIViewRepository registeredViewsRepository;
        private readonly ViewContexRepository viewContexRepository;
        private readonly ViewQueueRepository viewQueueRepository;
        private readonly Type viewType;
        private readonly bool pushToViewQueue;
        private readonly bool instantly;

        public HideUIViewInstruction(
            UIViewRepository registeredViewsRepository,
            ViewContexRepository viewContexRepository,
            ViewQueueRepository viewQueueRepository,
            Type viewType,
            bool pushToViewQueue,
            bool instantly
            )
        {
            this.registeredViewsRepository = registeredViewsRepository;
            this.viewContexRepository = viewContexRepository;
            this.viewQueueRepository = viewQueueRepository;
            this.viewType = viewType;
            this.pushToViewQueue = pushToViewQueue;
            this.instantly = instantly;
        }

        protected override async Task OnExecute(CancellationToken cancellationToken)
        {
            bool found = registeredViewsRepository.TryGet(viewType, out UIView uiView);

            if (!found)
            {
                UnityEngine.Debug.LogError($"Tried to Hide {nameof(UIView)} of type {viewType.Name}, " +
                    $"but it was not registered, at {nameof(HideUIViewInstruction)}");

                return;
            }

            if (uiView.IsPopup)
            {
                bool pupupFound = viewContexRepository.TryGetPopup(uiView, out ViewContex viewContext);

                if(!pupupFound)
                {
                    UnityEngine.Debug.LogError($"Tried to Hide {nameof(UIView)} as Popup, " +
                        $"but it was not showing on the first place, at {nameof(HideUIViewInstruction)}");
                    return;
                }

                viewContext.PopupUIViews.Remove(uiView);
            }
            else
            {
                bool viewFound = viewContexRepository.TryGet(uiView, out ViewContex viewContext);

                if(!viewFound)
                {
                    UnityEngine.Debug.LogError($"Tried to Hide {nameof(UIView)}, " +
                        $"but it was not showing on the first place, at {nameof(HideUIViewInstruction)}");
                    return;
                }

                viewContexRepository.Remove(viewContext);

                List<Task> hideTasks = new List<Task>();

                foreach(UIView popup in viewContext.PopupUIViews)
                {
                    hideTasks.Add(popup.Hide(instantly, cancellationToken));
                }

                if (pushToViewQueue)
                {
                    viewQueueRepository.Push(uiView.GetType());
                }

                await Task.WhenAll(hideTasks);
            }

            await uiView.Hide(instantly, cancellationToken);
        }
    }
}
