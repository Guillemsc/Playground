using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.State;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UseCases.TrySpawnPointGoal
{
    public class TrySpawnPointGoalUseCase : ITrySpawnPointGoalUseCase
    {
        private readonly IFactory<PointGoalEntityViewDefinition, IDisposable<PointGoalEntityView>> pointGoalEntityViewFactory;
        private readonly IRepository<IDisposable<PointGoalEntityView>> pointGoalEntityViewRepository;
        private readonly PointsState pointsState;

        public TrySpawnPointGoalUseCase(
            IFactory<PointGoalEntityViewDefinition, IDisposable<PointGoalEntityView>> pointGoalEntityViewFactory,
            IRepository<IDisposable<PointGoalEntityView>> pointGoalEntityViewRepository,
            PointsState pointsState
            )
        {
            this.pointGoalEntityViewFactory = pointGoalEntityViewFactory;
            this.pointGoalEntityViewRepository = pointGoalEntityViewRepository;
            this.pointsState = pointsState;
        }

        public bool Execute(
            float position
            )
        {
            ++pointsState.TotalSpawnedPoints;

            bool created = pointGoalEntityViewFactory.TryCreate(
                new PointGoalEntityViewDefinition(
                    pointsState.TotalSpawnedPoints
                    ),
                out IDisposable<PointGoalEntityView> creation
                );

            if(!created)
            {
                UnityEngine.Debug.LogError($"{nameof(PointGoalEntityView)} could not be created, " +
                    $"at {nameof(TrySpawnPointGoalUseCase)}");
                return false;
            }

            pointGoalEntityViewRepository.Add(creation);

            Vector2 finalPosition = new Vector2(creation.Value.transform.position.x, position);

            creation.Value.transform.position = finalPosition;

            return true;
        }
    }
}
