using Juce.Core.Sequencing;
using Juce.CoreUnity.UI;
using System;

namespace Playground.Services.ViewStack
{
    public class MoveBackUIViewInstruction : InstantInstruction
    {
        private readonly UIViewRepository registeredViewsRepository;
        private readonly Type viewType;

        public MoveBackUIViewInstruction(
            UIViewRepository registeredViewsRepository,
            Type viewType
            )
        {
            this.registeredViewsRepository = registeredViewsRepository;
            this.viewType = viewType;
        }

        protected override void OnInstantExecute()
        {
            bool found = registeredViewsRepository.TryGet(viewType, out UIView uiView);

            if (!found)
            {
                UnityEngine.Debug.LogError($"Tried to Show {nameof(UIView)} of type {viewType.Name}, " +
                    $"but it was not registered, at {nameof(ShowLastUIViewInstruction)}");

                return;
            }

            UIFrame.Instance.MoveBack(uiView);
        }
    }
}
