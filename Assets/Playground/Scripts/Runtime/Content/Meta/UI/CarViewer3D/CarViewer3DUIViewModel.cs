using Juce.Core.Observables;
using Juce.CoreUnity.DragPointerCallback;
using UnityEngine.EventSystems;

namespace Playground.Content.Meta.UI.CarViewer3D
{
    public class CarViewer3DUIViewModel
    {
        public ObservableEvent<DragPointerCallbacks, PointerEventData> OnStartDraggingCarViewEvent { get; }
            = new ObservableEvent<DragPointerCallbacks, PointerEventData>();
        public ObservableEvent<DragPointerCallbacks, PointerEventData> OnStopDraggingCarViewEvent { get; }
            = new ObservableEvent<DragPointerCallbacks, PointerEventData>();
        public ObservableEvent<DragPointerCallbacks, PointerEventData> OnDragCarViewEvent { get; }
            = new ObservableEvent<DragPointerCallbacks, PointerEventData>();
    }
}
