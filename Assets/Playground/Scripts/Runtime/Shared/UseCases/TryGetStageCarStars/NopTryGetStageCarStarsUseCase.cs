namespace Playground.Shared.UseCases
{
    public class NopTryGetStageCarStarsUseCase : ITryGetStageCarStarsUseCase
    {
        public bool Execute(string stageTypeId, string carTypeId, out int stars)
        {
            stars = 0;
            return true;
        }
    }
}
