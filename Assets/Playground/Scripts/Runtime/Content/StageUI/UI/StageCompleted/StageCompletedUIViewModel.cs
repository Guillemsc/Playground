using Juce.Core.Observables;
using Juce.CoreUnity.PointerCallback;

namespace Playground.Content.StageUI.UI.StageCompleted
{
    public class StageCompletedUIViewModel
    {
        public ObservableEvent<StageCompletedUIView, PointerCallbacks> OnPlayAgainClickedEvent { get; }
            = new ObservableEvent<StageCompletedUIView, PointerCallbacks>();

        public ObservableCommand CanUnloadStageCommand { get; } = new ObservableCommand();
    }
}
