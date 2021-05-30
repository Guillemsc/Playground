using Juce.Core.Observables;
using Juce.CoreUnity.PointerCallback;

namespace Playground.Content.Stage.VisualLogic.UI.DemoStages
{
    public class DemoStagesUIViewModel
    {
        public ObservableEvent<DemoStageButtonUIEntry, PointerCallbacks> OnDemoStageButtonClickedEvent { get; } =
            new ObservableEvent<DemoStageButtonUIEntry, PointerCallbacks>();
    }
}
