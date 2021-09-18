using Juce.Core.Events;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Playground.Content.Stage.Logic.Entities;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.Logic.Snapshots;
using Playground.Content.Stage.Logic.State;

namespace Playground.Content.Stage.Logic.UseCases.StartStage
{
    public class StartStageUseCase : IStartStageUseCase
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly StageState stageState;
        private readonly IKeyValueRepository<int, ShipEntity> shipEntityRepository;

        public StartStageUseCase(
            IEventDispatcher eventDispatcher,
            StageState stageState,
            IKeyValueRepository<int, ShipEntity> shipEntityRepository
            )
        {
            this.eventDispatcher = eventDispatcher;
            this.stageState = stageState;
            this.shipEntityRepository = shipEntityRepository;
        }

        public void Execute()
        {
            bool shipFound = shipEntityRepository.TryGet(
                stageState.UsingShiptInstanceId,
                out ShipEntity shipEntity
                );

            if(!shipFound)
            {
                return;
            }

            eventDispatcher.Dispatch(new StartStageOutEvent(
                ShipEntitySnapshot.ToSnapshot(shipEntity)
                ));
        }
    }
}
