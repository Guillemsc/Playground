using Playground.Content.Stage.VisualLogic.View.Car;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class SetCarViewControllerStateInstruction
    {
        private readonly CarViewController carViewController;
        private readonly CarViewControllerState carViewControllerState;

        public SetCarViewControllerStateInstruction(
            CarViewController carViewController,
            CarViewControllerState carViewControllerState
            )
        {
            this.carViewController = carViewController;
            this.carViewControllerState = carViewControllerState;
        }

        public void Execute()
        {
            carViewController.CarViewControllerState = carViewControllerState;
        }
    }
}
