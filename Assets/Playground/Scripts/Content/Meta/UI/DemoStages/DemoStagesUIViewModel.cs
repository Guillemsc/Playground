using Juce.Core.Events.Generic;
using Juce.CoreUnity.PointerCallback;
using System;

namespace Playground.Content.Stage.VisualLogic.UI.DemoStages
{
    public class DemoStagesUIViewModel
    {
        public GenericEvent<PointerCallbacks, EventArgs> OnDemoStagesClicked;
    }
}
