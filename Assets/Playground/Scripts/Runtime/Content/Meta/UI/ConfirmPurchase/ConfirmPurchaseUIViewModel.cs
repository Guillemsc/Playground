using Juce.Core.Observables;
using Juce.CoreUnity.PointerCallback;
using System;
using UnityEngine;

namespace Playground.Content.Meta.UI.ConfirmPurchase
{
    public class ConfirmPurchaseUIViewModel
    {
        public ObservableEvent<PointerCallbacks, EventArgs> OnConfirmationClickedEvent { get; }
            = new ObservableEvent<PointerCallbacks, EventArgs>();
        public ObservableEvent<PointerCallbacks, EventArgs> OnClosePanelClickedEvent { get; }
            = new ObservableEvent<PointerCallbacks, EventArgs>();

        public ObservableVariable<int> PriceVariable { get; }
            = new ObservableVariable<int>();
        public ObservableVariable<Sprite> IconVariable { get; }
            = new ObservableVariable<Sprite>();
    }
}
