namespace Playground.Shared.UseCases
{
    public interface ITryGetStageCarStarsUseCase
    {
        bool Execute(string stageTypeId, string carTypeId, out int stars);
    }
}
