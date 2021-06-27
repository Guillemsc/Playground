using Playground.Configuration.Stage;

namespace Playground.Content.Shared.UseCases
{
    public interface IGetStageStarsFromTimingUseCase
    {
        int Execute(
            StageStarsConfiguration stageStarsConfiguration,
            string carTypeId,
            float timing
            );
    }
}
