using Juce.Core.Disposables;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.DespawnPointGoal
{
    public interface IDespawnPointGoalUseCase
    {
        void Execute(IDisposable<PointGoalEntityView> pointGoalEntityView);
    }
}
