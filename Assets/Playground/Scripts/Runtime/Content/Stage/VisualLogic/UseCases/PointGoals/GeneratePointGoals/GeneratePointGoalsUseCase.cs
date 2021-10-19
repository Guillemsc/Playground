using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.UseCases.TrySpawnPointGoal;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UseCases.GeneratePointGoals
{
    public class GeneratePointGoalsUseCase : IGeneratePointGoalsUseCase
    {
        private readonly IReadOnlySingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository;
        private readonly IRepository<IDisposable<PointGoalEntityView>> pointGoalsEntityViewRepository;
        private readonly Transform sectionsStartPosition;
        private readonly PointGoalsVisualLogicSetup visualLogicSectionsSetup;
        private readonly StageSettings stageSettings;
        private readonly ITrySpawnPointGoalUseCase trySpawnPointGoalUseCase;

        public GeneratePointGoalsUseCase(
            IReadOnlySingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository,
            IRepository<IDisposable<PointGoalEntityView>> pointGoalsEntityViewRepository,
            Transform sectionsStartPosition,
            PointGoalsVisualLogicSetup visualLogicSectionsSetup,
            StageSettings stageSettings,
            ITrySpawnPointGoalUseCase trySpawnPointGoalUseCase
            )
        {
            this.shipEntityViewRepository = shipEntityViewRepository;
            this.pointGoalsEntityViewRepository = pointGoalsEntityViewRepository;
            this.sectionsStartPosition = sectionsStartPosition;
            this.visualLogicSectionsSetup = visualLogicSectionsSetup;
            this.stageSettings = stageSettings;
            this.trySpawnPointGoalUseCase = trySpawnPointGoalUseCase;
        }

        public void Execute()
        {
            bool shipFound = shipEntityViewRepository.TryGet(out IDisposable<ShipEntityView> shipEntityView);

            if (!shipFound)
            {
                return;
            }

            while (true)
            {
                if (pointGoalsEntityViewRepository.Items.Count == 0)
                {
                    trySpawnPointGoalUseCase.Execute(sectionsStartPosition.position.y);

                    continue;
                }

                float forwardDistance = shipEntityView.Value.transform.position.y + stageSettings.PointGoalsForwardSpawnDistance;

                IDisposable<PointGoalEntityView> lastPointGoal
                    = pointGoalsEntityViewRepository.Items[pointGoalsEntityViewRepository.Items.Count - 1];

                float nextPosition = lastPointGoal.Value.transform.position.y + visualLogicSectionsSetup.DistanceBetweenPointGoals;

                if (nextPosition > forwardDistance)
                {
                    break;
                }

                trySpawnPointGoalUseCase.Execute(nextPosition);
            }
        }
    }
}
