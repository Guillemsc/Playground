using Juce.Core.Subscribables;
using Playground.Content.StageUI.UI.Effects.UseCases.SetPoints;
using System.Threading;

namespace Playground.Content.StageUI.UI.Points
{
    public class PointsUIInteractor : IPointsUIInteractor, ISubscribable
    {
        private readonly PointsUIViewModel viewModel;
        private readonly ISetPointsUseCase setPointsUseCase;

        public PointsUIInteractor(
            PointsUIViewModel viewModel,
            ISetPointsUseCase setPointsUseCase
            )
        {
            this.viewModel = viewModel;
            this.setPointsUseCase = setPointsUseCase;
        }

        public void Subscribe()
        {

        }

        public void Unsubscribe()
        {

        }

        public void Refresh()
        {
            SetPoints(points: 0, instantly: true);
        }

        public void SetPoints(int points, bool instantly = false)
        {
            setPointsUseCase.Execute(points, instantly, CancellationToken.None).RunAsync();
        }
    }
}
