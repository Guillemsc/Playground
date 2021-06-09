using Juce.Core.Observables;
using Juce.CoreUnity.PointerCallback;
using System;

namespace Playground.Content.Meta.UI.DemoStages
{
    public class DemoStagesUIViewModel
    {
        public ObservableEvent<PointerCallbacks, EventArgs> OnBackClickedEvent { get; } = new ObservableEvent<PointerCallbacks, EventArgs>();

        public ObservableEvent<DemoStageButtonUIEntry, PointerCallbacks> OnDemoStageButtonClickedEvent { get; } =
            new ObservableEvent<DemoStageButtonUIEntry, PointerCallbacks>();
    }
}
