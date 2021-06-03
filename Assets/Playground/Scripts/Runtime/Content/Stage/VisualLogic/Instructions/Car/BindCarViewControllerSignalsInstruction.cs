using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Content.Stage.VisualLogic.View.Signals;
using System;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class BindCarViewControllerSignalsInstruction
    {
        private readonly CarViewControllerSignals carViewControllerSignals;
        private readonly CarViewController carViewController;

        public BindCarViewControllerSignalsInstruction(
            CarViewControllerSignals carViewControllerSignals,
            CarViewController carViewController
            )
        {
            this.carViewControllerSignals = carViewControllerSignals;
            this.carViewController = carViewController;
        }

        public void Execute()
        {
            carViewController.OnAccelerateOrBrake += (CarViewController carViewController, EventArgs eventArgs) =>
            {
                carViewControllerSignals.AcceleratesOrBrakesSignal.Trigger(carViewControllerSignals, EventArgs.Empty);
            };
        }
    }
}
