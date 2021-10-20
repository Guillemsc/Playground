namespace Playground.Content.Stage.VisualLogic.UseCases.TrySpawnPointGoal
{
    public interface ITrySpawnPointGoalUseCase
    {
        bool Execute(
            int pointValue,
            float position
            );
    }
}
