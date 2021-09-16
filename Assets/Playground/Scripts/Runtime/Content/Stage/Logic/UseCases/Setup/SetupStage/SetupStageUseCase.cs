using Juce.Core.Events;
using Playground.Content.Stage.Logic.Entities;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.Logic.Setup;
using Playground.Content.Stage.Logic.Snapshots;
using Playground.Content.Stage.Logic.UseCases.TryCreateShip;

namespace Playground.Content.Stage.Logic.UseCases.SetupStage
{
    public class SetupStageUseCase : ISetupStageUseCase
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly LogicStageSetup logicStageSetup;
        private readonly ITryCreateShipUseCase tryCreateShipUseCase;

        public SetupStageUseCase(
            IEventDispatcher eventDispatcher,
            LogicStageSetup logicStageSetup,
            ITryCreateShipUseCase tryCreateShipUseCase
            )
        {
            this.logicStageSetup = logicStageSetup;
            this.eventDispatcher = eventDispatcher;
            this.tryCreateShipUseCase = tryCreateShipUseCase;
        }

        public void Execute()
        {
            bool shipCreated = tryCreateShipUseCase.Execute(
                logicStageSetup.ShipSetup,
                out ShipEntity shipEntity
                );

            if(!shipCreated)
            {
                return;
            }

            eventDispatcher.Dispatch(new SetupStageOutEvent(
                ShipEntitySnapshot.ToSnapshot(shipEntity)
                ));
        }
    }
}
