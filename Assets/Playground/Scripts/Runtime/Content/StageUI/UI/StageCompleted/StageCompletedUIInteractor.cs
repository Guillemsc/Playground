using Juce.CoreUnity.UI;
using System;

namespace Playground.Content.StageUI.UI.StageCompleted
{
    public class StageCompletedUIInteractor : UIInteractor
    {
        private readonly StageCompletedUIViewModel viewModel;
        private readonly StageCompletedUIUseCases useCases;

        public StageCompletedUIInteractor(
            StageCompletedUIViewModel viewModel,
            StageCompletedUIUseCases useCases
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

        public void SetStars(int stars)
        {
            viewModel.StarsVariable.Value = stars;
        }

        public void RegisterToCanUnloadStage(Action canUnloadStage)
        {
            viewModel.CanUnloadStageCommand.OnExecute += canUnloadStage;
        }

        public void UnregisterToCanUnloadStage(Action canUnloadStage)
        {
            viewModel.CanUnloadStageCommand.OnExecute -= canUnloadStage;
        }
    }
}
