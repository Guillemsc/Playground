using Juce.Core.Events.Generic;
using Juce.CoreUnity.UI;
using System;

namespace Playground.Content.StageUI.UI.ActionInputDetection
{
    public interface IActionInputDetectionUIInteractor : IUIInteractor
    {
        public event GenericEvent<ActionInputDetectionUIInteractor, EventArgs> InputActionReceived;
    }
}
