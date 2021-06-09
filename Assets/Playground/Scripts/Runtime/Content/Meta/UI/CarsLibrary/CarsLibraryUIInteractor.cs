using Juce.CoreUnity.UI;

namespace Playground.Content.Meta.UI.CarsLibrary
{
    public class CarsLibraryUIInteractor : UIInteractor
    {
        private readonly CarsLibraryUIViewModel viewModel;
        private readonly CarsLibraryUIUseCases useCases;

        public CarsLibraryUIInteractor(
            CarsLibraryUIViewModel viewModel,
            CarsLibraryUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Subscribe()
        {

        }

        public void Unsubscribe()
        {

        }
    }
}
