using Juce.Core.Subscribables;

namespace Playground.Content.StageUI.UI.Points
{
    public class PointsUIController : ISubscribable
    {
        private readonly PointsUIViewModel viewModel;

        public PointsUIController(
            PointsUIViewModel viewModel
            )
        {
            this.viewModel = viewModel;
        }

        public void Subscribe()
        {

        }

        public void Unsubscribe()
        {

        }
    }
}
