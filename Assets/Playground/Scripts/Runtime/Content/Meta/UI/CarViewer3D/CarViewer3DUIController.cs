using Juce.CoreUnity.DragPointerCallback;
using UnityEngine.EventSystems;

namespace Playground.Content.Meta.UI.CarViewer3D
{
    public class CarViewer3DUIController
    {
        private readonly CarViewer3DUIViewModel viewModel;
        private readonly CarViewer3DUIUseCases useCases;

        public CarViewer3DUIController(
            CarViewer3DUIViewModel viewModel,
            CarViewer3DUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Subscribe()
        {
            viewModel.OnStartDraggingCarViewEvent.OnExecute += OnStartDraggingCarViewEvent;
            viewModel.OnStopDraggingCarViewEvent.OnExecute += OnStopDraggingCarViewEvent;
            viewModel.OnDragCarViewEvent.OnExecute += OnDragCarViewEvent;
        }

        public void Unsubscribe()
        {
            viewModel.OnStartDraggingCarViewEvent.OnExecute -= OnStartDraggingCarViewEvent;
            viewModel.OnStopDraggingCarViewEvent.OnExecute -= OnStopDraggingCarViewEvent;
            viewModel.OnDragCarViewEvent.OnExecute -= OnDragCarViewEvent;
        }

        private void OnStartDraggingCarViewEvent(DragPointerCallbacks dragPointerCallbacks, PointerEventData pointerEventData)
        {
            useCases.StartManuallyRotatingCarViewUseCase.Execute();
        }

        private void OnStopDraggingCarViewEvent(DragPointerCallbacks dragPointerCallbacks, PointerEventData pointerEventData)
        {
            useCases.StopManuallyRotatingCarViewUseCase.Execute(-pointerEventData.delta.x);
        }

        private void OnDragCarViewEvent(DragPointerCallbacks dragPointerCallbacks, PointerEventData pointerEventData)
        {
            useCases.ManuallyRotate3DCarUseCase.Execute(-pointerEventData.delta.x);
        }
    }
}
