using Playground.Content.Stage.Logic.Snapshots;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetupStage
{
    public interface ISetupStageUseCase
    {
        void Execute(
            ShipEntitySnapshot ShipEntitySnapshot
            );
    }
}
