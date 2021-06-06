using Juce.Core.Events.Generic;
using Juce.CoreUnity.PointerCallback;
using System;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class MainMenuUIViewModel 
    {
        public GenericEvent<PointerCallbacks, EventArgs> OnDemoStagesClicked;
        public ObservableVariable<string> VersionValiable { get; } = new ObservableVariable<string>();
    }
}
