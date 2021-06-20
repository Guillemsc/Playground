using Juce.Core.Observables;
using Juce.CoreUnity.PointerCallback;
using System;

namespace Playground.Content.Meta.UI.Credits
{
    public class CreditsUIViewModel
    {
        public ObservableEvent<PointerCallbacks, EventArgs> OnScreenClickedEvent { get; } = new ObservableEvent<PointerCallbacks, EventArgs>();
    }
}
