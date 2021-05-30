using Juce.Core.Observables;
using Juce.CoreUnity.PointerCallback;

namespace Playground.Content.StageUI.UI.ScreenCarControls
{
    public class ScreenCarControlsUIViewModel
    {
        public ObservableEvent<ScreenCarControlsUIView, PointerCallbacks> OnLeftPointerCallbacksDownEvent { get; }
            = new ObservableEvent<ScreenCarControlsUIView, PointerCallbacks>();
        public ObservableEvent<ScreenCarControlsUIView, PointerCallbacks> OnRightPointerCallbacksDown { get; }
            = new ObservableEvent<ScreenCarControlsUIView, PointerCallbacks>();
        public ObservableEvent<ScreenCarControlsUIView, PointerCallbacks> OnAcceleratePointerCallbacksDown { get; } 
            = new ObservableEvent<ScreenCarControlsUIView, PointerCallbacks>();
        public ObservableEvent<ScreenCarControlsUIView, PointerCallbacks> OnBreakPointerCallbacksDown { get; } 
            = new ObservableEvent<ScreenCarControlsUIView, PointerCallbacks>();
    }
}
