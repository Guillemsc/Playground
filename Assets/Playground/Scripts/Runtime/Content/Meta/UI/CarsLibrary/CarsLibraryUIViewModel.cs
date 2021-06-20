using Juce.Core.Observables;
using Juce.CoreUnity.PointerCallback;
using System;

namespace Playground.Content.Meta.UI.CarsLibrary
{
    public class CarsLibraryUIViewModel
    {
        public ObservableEvent<PointerCallbacks, EventArgs> OnBackClickedEvent { get; } 
            = new ObservableEvent<PointerCallbacks, EventArgs>();

        public ObservableEvent<CarLibraryUIEntry, PointerCallbacks> OnCarClickedEvent { get; }
            = new ObservableEvent<CarLibraryUIEntry, PointerCallbacks>();
    }
}
