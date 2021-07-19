using Juce.Core.Observables;
using Juce.CoreUnity.PointerCallback;
using System;

namespace Playground.Content.Meta.UI.Shop
{
    public class ShopUIViewModel
    {
        public ObservableEvent<PointerCallbacks, EventArgs> OnBackClickedEvent { get; }
            = new ObservableEvent<PointerCallbacks, EventArgs>();

        public ObservableEvent<ShopCarUIEntry, PointerCallbacks> OnShopCarClickedEvent { get; }
            = new ObservableEvent<ShopCarUIEntry, PointerCallbacks>();
    }
}
