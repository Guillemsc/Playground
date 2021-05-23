using Playground.Content.Stage.VisualLogic.View.CheckPoints;
using Playground.Content.Stage.Logic.CheckPoints;

namespace Playground.Content.Stage.Setup
{
    public class CheckPointsRepositoryFactory
    {
        public bool Create(CheckPointsView checkPointsView, out CheckPointRepository checkPointRepository)
        {
            if(checkPointsView == null)
            {
                checkPointRepository = null;
                return false;
            }

            checkPointRepository = new CheckPointRepository();

            for(int i = 0; i < checkPointsView.CheckPoints.Count; ++i)
            {
                CheckPoint checkPoint = new CheckPoint(i);

                checkPointRepository.Add(checkPoint);
            }

            return true;
        }
    }
}
