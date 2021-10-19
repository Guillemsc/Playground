using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.DespawnPointGoal
{
    public class DespawnPointGoalUseCase : IDespawnPointGoalUseCase
    {
        private readonly IRepository<IDisposable<PointGoalEntityView>> pointGoalEntityViewRepository;

        public DespawnPointGoalUseCase(
            IRepository<IDisposable<PointGoalEntityView>> pointGoalEntityViewRepository
            )
        {
            this.pointGoalEntityViewRepository = pointGoalEntityViewRepository;
        }

        public void Execute(IDisposable<PointGoalEntityView> pointGoalEntityView)
        {
            pointGoalEntityViewRepository.Remove(pointGoalEntityView);

            pointGoalEntityView.Dispose();
        }
    }
}
