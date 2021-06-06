using Juce.Core.Observables;
using Juce.CoreUnity.PointerCallback;

namespace Playground.Content.StageUI.UI.StageCompleted
{
    public class StageCompletedUIViewModel
    {
        public ObservableVariable<int> StarsVariable { get; } = new ObservableVariable<int>();
        public ObservableEvent<StageCompletedUIView, PointerCallbacks> ContinueEvent { get; } = new ObservableEvent<StageCompletedUIView, PointerCallbacks>();
        public ObservableEvent<StageCompletedUIView, PointerCallbacks> PlayAgainEvent { get; } = new ObservableEvent<StageCompletedUIView, PointerCallbacks>();

        public ObservableCommand CanUnloadStageCommand { get; } = new ObservableCommand();
    }
}
