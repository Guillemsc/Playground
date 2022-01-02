namespace Playground.Content.Meta.UI.StageEnd.UseCases.Init
{
    public class InitUseCase : IInitUseCase
    {
        private readonly StageEndUIViewModel stageEndUIViewModel;

        public InitUseCase(
            StageEndUIViewModel stageEndUIViewModel
            )
        {
            this.stageEndUIViewModel = stageEndUIViewModel;
        }

        public void Execute(int currentPoints)
        {
            stageEndUIViewModel.CurrentPointsVariable.Value = currentPoints.ToString();
            stageEndUIViewModel.BestPointsVariable.Value = $"Best {999}";
        }
    }
}
