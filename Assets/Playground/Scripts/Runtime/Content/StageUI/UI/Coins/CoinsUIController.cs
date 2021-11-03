using Juce.Core.Subscribables;

namespace Playground.Content.StageUI.UI.Coins
{
    public class CoinsUIController : ISubscribable
    {
        private readonly CoinsUIViewModel viewModel;

        public CoinsUIController(
            CoinsUIViewModel viewModel
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
