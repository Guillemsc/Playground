using Juce.CoreUnity.UI;

namespace Playground.Content.Stage.VisualLogic.UI.MainMenu
{
    public class MainMenuUIInteractor : UIInteractor
    {
        private readonly MainMenuUIViewModel viewModel;
        private readonly MainMenuUIUseCases useCases;

        public MainMenuUIInteractor(
            MainMenuUIViewModel viewModel,
            MainMenuUIUseCases useCases
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
