using Playground.Content.Stage.Logic.Snapshots;

namespace Playground.Content.Stage.VisualLogic.UseCases.StartStage
{
    public interface IStartStageUseCase
    {
        void Execute(
            ShipEntitySnapshot ShipEntitySnapshot
            );
    }
}
