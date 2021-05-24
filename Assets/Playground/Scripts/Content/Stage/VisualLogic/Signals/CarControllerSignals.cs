using System;

namespace Playground.Content.Stage.VisualLogic.View.Signals
{
    public class CarControllerSignals
    {
        public GenericSignal<CarControllerSignals, EventArgs> LeftSignal { get; } = new GenericSignal<CarControllerSignals, EventArgs>();
        public GenericSignal<CarControllerSignals, EventArgs> RightSignal { get; } = new GenericSignal<CarControllerSignals, EventArgs>();
        public GenericSignal<CarControllerSignals, EventArgs> AccelerateSignal { get; } = new GenericSignal<CarControllerSignals, EventArgs>();
        public GenericSignal<CarControllerSignals, EventArgs> BreakSignal { get; } = new GenericSignal<CarControllerSignals, EventArgs>();
    }
}
