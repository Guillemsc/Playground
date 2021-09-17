using Juce.Core.Observables;
using UnityEngine.EventSystems;

namespace Playground.Content.StageUI.UI.ActionInputDetection
{
    public class ActionInputDetectionUIViewModel
    {
        public ObservableEvent<ActionInputDetectionUIView, PointerEventData> OnInputActionEvent { get; }
            = new ObservableEvent<ActionInputDetectionUIView, PointerEventData>();
    }
}
