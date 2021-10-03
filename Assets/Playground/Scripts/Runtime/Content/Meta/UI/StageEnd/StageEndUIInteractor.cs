using Juce.Core.Subscribables;

namespace Playground.Content.Meta.UI.StageEnd
{
    public class StageEndUIInteractor : IStageEndUIInteractor, ISubscribable
    {
        private readonly StageEndUIViewModel viewModel;

        public StageEndUIInteractor(
            StageEndUIViewModel viewModel
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

        public void Refresh()
        {

        }
    }
}
