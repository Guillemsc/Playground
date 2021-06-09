using Juce.Core.Events.Generic;
using Juce.Core.Observables;
using Juce.CoreUnity.PointerCallback;
using System;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class MainMenuUIViewModel 
    {
        public ObservableEvent<PointerCallbacks, EventArgs> OnCarLibraryClickedEvent { get; } = new ObservableEvent<PointerCallbacks, EventArgs>();
        public ObservableEvent<PointerCallbacks, EventArgs> OnDemoStagesClickedEvent { get; } = new ObservableEvent<PointerCallbacks, EventArgs>();

        public ObservableVariable<string> VersionValiable { get; } = new ObservableVariable<string>();
    }
}
