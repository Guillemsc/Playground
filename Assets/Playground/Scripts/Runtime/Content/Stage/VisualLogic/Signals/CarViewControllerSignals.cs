using System;

namespace Playground.Content.Stage.VisualLogic.View.Signals
{
    public class CarViewControllerSignals
    {
        public GenericSignal<CarViewControllerSignals, EventArgs> AcceleratesOrBrakesSignal { get; } = new GenericSignal<CarViewControllerSignals, EventArgs>();
    }
}
