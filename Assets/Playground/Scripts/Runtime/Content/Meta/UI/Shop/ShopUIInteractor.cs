using Juce.CoreUnity.UI;

namespace Playground.Content.Meta.UI.Shop
{
    public class ShopUIInteractor : UIInteractor
    {
        private readonly ShopUIViewModel viewModel;
        private readonly ShopUIUseCases useCases;

        public ShopUIInteractor(
            ShopUIViewModel viewModel,
            ShopUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Refresh()
        {
            
        }

        public void Subscribe()
        {

        }

        public void Unsubscribe()
        {

        }
    }
}
