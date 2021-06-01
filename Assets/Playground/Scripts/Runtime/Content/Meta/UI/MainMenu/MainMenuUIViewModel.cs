using Juce.Core.Events.Generic;
using Juce.CoreUnity.PointerCallback;
using System;

namespace Playground.Content.Stage.VisualLogic.UI.MainMenu
{
    public class MainMenuUIViewModel 
    {
        public GenericEvent<PointerCallbacks, EventArgs> OnDemoStagesClicked;
        public ObservableVariable<string> VersionValiable { get; } = new ObservableVariable<string>();
    }
}
