using Playground.Content.Stage.VisualLogic.View.CheckPoints;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class SetCheckPointAsCrossed
    {
        private readonly CheckPointsView checkPointsView;
        private readonly int checkPointIndex;

        public SetCheckPointAsCrossed(
            CheckPointsView checkPointsView,
            int checkPointIndex
            )
        {
            this.checkPointsView = checkPointsView;
            this.checkPointIndex = checkPointIndex;
        }

        public void Execute()
        {
            bool found = checkPointsView.TryGet(checkPointIndex, out CheckPointView checkPointView);

            if (!found)
            {
                return;
            }

            checkPointView.SetAsCrossed();
        }
    }
}
