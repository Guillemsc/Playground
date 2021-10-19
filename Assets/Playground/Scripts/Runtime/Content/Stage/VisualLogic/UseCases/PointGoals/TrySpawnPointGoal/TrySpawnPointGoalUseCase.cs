using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Playground.Content.Stage.VisualLogic.Entities;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UseCases.TrySpawnPointGoal
{
    public class TrySpawnPointGoalUseCase : ITrySpawnPointGoalUseCase
    {
        private readonly IFactory<PointGoalEntityViewDefinition, IDisposable<PointGoalEntityView>> pointGoalEntityViewFactory;
        private readonly IRepository<IDisposable<PointGoalEntityView>> pointGoalEntityViewRepository;

        public TrySpawnPointGoalUseCase(
            IFactory<PointGoalEntityViewDefinition, IDisposable<PointGoalEntityView>> pointGoalEntityViewFactory,
            IRepository<IDisposable<PointGoalEntityView>> pointGoalEntityViewRepository
            )
        {
            this.pointGoalEntityViewFactory = pointGoalEntityViewFactory;
            this.pointGoalEntityViewRepository = pointGoalEntityViewRepository;
        }

        public bool Execute(float position)
        {
            bool created = pointGoalEntityViewFactory.TryCreate(
                new PointGoalEntityViewDefinition(),
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
