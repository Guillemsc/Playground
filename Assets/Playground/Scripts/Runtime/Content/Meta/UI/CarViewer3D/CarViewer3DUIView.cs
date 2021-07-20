using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.DragPointerCallback;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.Meta.UI.CarViewer3D
{
    public class CarViewer3DUIView : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private DragPointerCallbacks carViewerDragPointerCallbacks = default;

        private CarViewer3DUIViewModel viewModel;

        private void Awake()
        {
            Contract.IsNotNull(carViewerDragPointerCallbacks, this);

            carViewerDragPointerCallbacks.OnBegin += OnCarViewerDragPointerCallbacksBegin;
            carViewerDragPointerCallbacks.OnDragging += OnCarViewerDragPointerCallbacksDragging;
            carViewerDragPointerCallbacks.OnEnd += OnCarViewerDragPointerCallbacksEnd;
        }

        private void OnDestroy()
        {
            carViewerDragPointerCallbacks.OnBegin -= OnCarViewerDragPointerCallbacksBegin;
            carViewerDragPointerCallbacks.OnDragging -= OnCarViewerDragPointerCallbacksDragging;
            carViewerDragPointerCallbacks.OnEnd -= OnCarViewerDragPointerCallbacksEnd;
        }

        public void Init(CarViewer3DUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private void OnCarViewerDragPointerCallbacksBegin(DragPointerCallbacks dragPointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.OnStartDraggingCarViewEvent.Execute(dragPointerCallbacks, pointerEventData);
        }

        private void OnCarViewerDragPointerCallbacksDragging(DragPointerCallbacks dragPointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.OnDragCarViewEvent.Execute(dragPointerCallbacks, pointerEventData);
        }

        private void OnCarViewerDragPointerCallbacksEnd(DragPointerCallbacks dragPointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.OnStopDraggingCarViewEvent.Execute(dragPointerCallbacks, pointerEventData);
        }
    }
}
