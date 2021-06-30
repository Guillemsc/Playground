namespace Playground.Shared.UseCases
{
    public interface ISetStageCarStarsUseCase
    {
        void Execute(string stageTypeId, string carTypeId, int starsToSet);
    }
}
