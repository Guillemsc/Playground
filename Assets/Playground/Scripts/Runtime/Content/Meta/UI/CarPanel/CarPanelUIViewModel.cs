using Juce.Core.Observables;
using Juce.CoreUnity.PointerCallback;
using System;

namespace Playground.Content.Meta.UI.CarPanel
{
    public class CarPanelUIViewModel
    {
        public ObservableEvent<PointerCallbacks, EventArgs> OnBackClickedEvent { get; }
            = new ObservableEvent<PointerCallbacks, EventArgs>();
        public ObservableEvent<PointerCallbacks, EventArgs> OnCarSelectedEvent { get; }
            = new ObservableEvent<PointerCallbacks, EventArgs>();
        public ObservableEvent<PointerCallbacks, EventArgs> OnCarPurchasedEvent { get; }
            = new ObservableEvent<PointerCallbacks, EventArgs>();

        public ObservableVariable<string> CarNameVariable { get; }
            = new ObservableVariable<string>();
        public ObservableVariable<string> CarDescriptionVariable { get; }
            = new ObservableVariable<string>();
    }
}
