using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetPointGoalAsCollected
{
    public class SetPointGoalAsCollectedUseCase : ISetPointGoalAsCollectedUseCase
    {
        private readonly IRepository<IDisposable<PointGoalEntityView>> pointGoalEntityViewRepository;

        public SetPointGoalAsCollectedUseCase(
            IRepository<IDisposable<PointGoalEntityView>> pointGoalEntityViewRepository
            )
        {
            this.pointGoalEntityViewRepository = pointGoalEntityViewRepository;
        }

        public void Execute(int pointGoalIndex)
        {
            foreach(IDisposable<PointGoalEntityView> item in pointGoalEntityViewRepository.Items)
            {
                if(item.Value.PointIndex == pointGoalIndex)
                {
                    item.Value.SetCollected();
                }
            }
        }
    }
}
