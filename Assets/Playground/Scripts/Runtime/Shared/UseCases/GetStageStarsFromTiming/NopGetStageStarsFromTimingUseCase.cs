using Playground.Configuration.Stage;

namespace Playground.Shared.UseCases
{
    public class NopGetStageStarsFromTimingUseCase : IGetStageStarsFromTimingUseCase
    {
        public int Execute(
            StageStarsConfiguration stageStarsConfiguration,
            string carTypeId,
            float seconds
            )
        {
            return 0;
        }
    }
}
