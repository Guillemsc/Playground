using System;

namespace Playground.Content.StageUI.UI.StageCompleted
{
    public class SetTimeUseCase : ISetTimeUseCase
    {
        private readonly StageCompletedUIViewModel viewModel;

        public SetTimeUseCase(StageCompletedUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public void Execute(TimeSpan timeSpan)
        {
            viewModel.TimeVariable.Value = timeSpan.ToString(@"mm\:ss");
        }
    }
}
