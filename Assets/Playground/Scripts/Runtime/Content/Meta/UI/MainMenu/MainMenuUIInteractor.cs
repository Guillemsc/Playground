using Juce.CoreUnity.UI;
using UnityEngine;

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
            viewModel.VersionValiable.Value = Application.version;
        }

        public void Unsubscribe()
        {

        }
    }
}
