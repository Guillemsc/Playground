using Playground.Content.Stage.VisualLogic.View.CheckPoints;
using Playground.Content.Stage.VisualLogic.View.Signals;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class RegisterCheckPointsSignalsInstruction
    {
        private readonly CheckPointsView checkPointsView;
        private readonly GenericSignal<CheckPointsView, CheckPointView> checkPointCrossedSignal;

        public RegisterCheckPointsSignalsInstruction(
            CheckPointsView checkPointsView,
            GenericSignal<CheckPointsView, CheckPointView> checkPointCrossedSignal
            )
        {
            this.checkPointsView = checkPointsView;
            this.checkPointCrossedSignal = checkPointCrossedSignal;
        }

        public void Execute()
        {
            checkPointsView.OnCheckPointCrossed += checkPointCrossedSignal.Trigger;
        }
    }
}
