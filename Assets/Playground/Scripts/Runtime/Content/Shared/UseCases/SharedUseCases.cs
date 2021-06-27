using Playground.Content.Shared.UseCases;

namespace Playground.Content.Shared
{
    public class SharedUseCases
    {
        public IGetStageStarsFromTimingUseCase GetStageStarsFromTimingUseCase { get; }

        public SharedUseCases(
            IGetStageStarsFromTimingUseCase getStageStarsFromTimingUseCase
            )
        {
            GetStageStarsFromTimingUseCase = getStageStarsFromTimingUseCase;
        }
    }
}
