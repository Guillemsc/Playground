using Juce.Core.Observables;
using Juce.CoreUnity.PointerCallback;

namespace Playground.Content.StageUI.UI.StageOverlay
{
    public class StageOverlayUIViewModel
    {
        public ObservableEvent<StageOverlayUIView, PointerCallbacks> OnReplayClickedEvent { get; }
            = new ObservableEvent<StageOverlayUIView, PointerCallbacks>();
    }
}
