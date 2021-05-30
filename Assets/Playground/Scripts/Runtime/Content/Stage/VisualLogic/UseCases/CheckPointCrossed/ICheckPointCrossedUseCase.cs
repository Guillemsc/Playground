using Playground.Content.Stage.VisualLogic.View.CheckPoints;

namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public interface ICheckPointCrossedUseCase
    {
        void Execute(CheckPointView checkPointView);
    }
}
