using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.UseCases.DespawnPointGoal;

namespace Playground.Content.Stage.VisualLogic.UseCases.CleanPointGoals
{
    public class CleanPointGoalsUseCase : ICleanPointGoalsUseCase
    {
        private readonly IReadOnlySingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository;
        private readonly IRepository<IDisposable<PointGoalEntityView>> pointGoalEntityViewRepository;
        private readonly StageSettings stageSettings;
        private readonly IDespawnPointGoalUseCase despawnPointGoalUseCase;

        public CleanPointGoalsUseCase(
            IReadOnlySingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository,
            IRepository<IDisposable<PointGoalEntityView>> pointGoalEntityViewRepository,
            StageSettings stageSettings,
            IDespawnPointGoalUseCase despawnPointGoalUseCase
            )
        {
            this.shipEntityViewRepository = shipEntityViewRepository;
            this.pointGoalEntityViewRepository = pointGoalEntityViewRepository;
            this.stageSettings = stageSettings;
            this.despawnPointGoalUseCase = despawnPointGoalUseCase;
        }

        public void Execute()
        {
            bool shipFound = shipEntityViewRepository.TryGet(out IDisposable<ShipEntityView> shipEntityView);

            if (!shipFound)
            {
                return;
            }

            if (pointGoalEntityViewRepository.Items.Count == 0)
            {
                return;
            }

            float backwardDistance = shipEntityView.Value.transform.position.y - stageSettings.SectionsBackwardDespawnDistance;

            IDisposable<PointGoalEntityView> oldestPointGoal = pointGoalEntityViewRepository.Items[0];

            float nextPosition = oldestPointGoal.Value.transform.position.y;

            if (nextPosition > backwardDistance)
            {
                return;
            }

            despawnPointGoalUseCase.Execute(oldestPointGoal);
        }
    }
}
