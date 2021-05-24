using Playground.Content.Stage.Libraries;
using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Content.Stage.VisualLogic.View.Signals;
using System;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class BindCarControllerSignalsInstruction
    {
        private readonly CarControllerSignals carControllerSignals;
        private readonly CarViewController carViewController;

        public BindCarControllerSignalsInstruction(
            CarControllerSignals carControllerSignals,
            CarViewController carViewController
            )
        {
            this.carControllerSignals = carControllerSignals;
            this.carViewController = carViewController;
        }

        public void Execute()
        {
            carControllerSignals.LeftSignal.OnTrigger += (CarControllerSignals carControllerSignals, EventArgs eventArgs) =>
            {
                carViewController.SteerLeft();
            };

            carControllerSignals.RightSignal.OnTrigger += (CarControllerSignals carControllerSignals, EventArgs eventArgs) =>
            {
                carViewController.SteerRight();
            };

            carControllerSignals.AccelerateSignal.OnTrigger += (CarControllerSignals carControllerSignals, EventArgs eventArgs) =>
            {
                carViewController.Accelerate();
            };

            carControllerSignals.BreakSignal.OnTrigger += (CarControllerSignals carControllerSignals, EventArgs eventArgs) =>
            {
                carViewController.Break();
            };
        }
    }
}
