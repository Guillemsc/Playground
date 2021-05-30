using Juce.Core.Sequencing;
using Juce.CoreUnity.UI;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Playground.Services.ViewStack
{
    public class ShowUIViewInstruction : Instruction
    {
        private readonly RegisteredViewsRepository registeredViewsRepository;
        private readonly ViewContexRepository viewContexRepository;
        private readonly Type viewType;
        private readonly bool instantly;

        public ShowUIViewInstruction(
            RegisteredViewsRepository registeredViewsRepository,
            ViewContexRepository viewContexRepository,
            Type viewType,
            bool instantly
            )
        {
            this.registeredViewsRepository = registeredViewsRepository;
            this.viewContexRepository = viewContexRepository;
            this.viewType = viewType;
            this.instantly = instantly;
        }

        protected override Task OnExecute(CancellationToken cancellationToken)
        {
            bool found = registeredViewsRepository.TryGet(viewType, out UIView uiView);

            if (!found)
            {
                UnityEngine.Debug.LogError($"Tried to Show {nameof(UIView)} of type {viewType.Name}, " +
                    $"but it was not registered, at {nameof(ShowUIViewInstruction)}");

                return Task.CompletedTask;
            }

            if(uiView.IsPopup)
            {
                ViewContex viewContext = viewContexRepository.Peek();

                if(viewContext == null)
                {
                    UnityEngine.Debug.LogError($"Tried to Show {nameof(UIView)} as Popup, " +
                        $"but it there was not a main view to attach to, at {nameof(ShowUIViewInstruction)}");
                    return Task.CompletedTask;
                }

                viewContext.PopupUIViews.Add(uiView);
            }
            else
            {
                viewContexRepository.Add(new ViewContex(uiView));
            }

            UIFrame.Instance.Push(uiView);

            return uiView.Show(instantly, cancellationToken);
        }
    }
}
