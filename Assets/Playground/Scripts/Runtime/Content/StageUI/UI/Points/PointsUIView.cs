using Juce.CoreUnity.UI;

namespace Playground.Content.StageUI.UI.Points
{
    public class PointsUIView : UIView
    {
        private PointsUIViewModel viewModel;

        private void Awake()
        {

        }

        public void Init(PointsUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
