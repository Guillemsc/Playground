using Juce.Core.Events.Generic;

namespace Playground.Content.Stage.VisualLogic.View.Signals
{
    public class GenericSignal<TSender, TEventArgs>
    {
        public event GenericEvent<TSender, TEventArgs> OnTrigger;

        public void Trigger(TSender sender, TEventArgs eventArgs)
        {
            OnTrigger?.Invoke(sender, eventArgs);
        }


    }
}
