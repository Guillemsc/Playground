namespace Playground.Shared.UseCases
{
    public class SharedUseCases
    {
        public IGetStageStarsFromTimingUseCase GetStageStarsFromTimingUseCase { get; }
        public ITryGetStageCarStarsUseCase TryGetStageCarStarsUseCase { get; }
        public ISetStageCarStarsUseCase SetStageCarStarsUseCase { get; }

        public SharedUseCases(
            IGetStageStarsFromTimingUseCase getStageStarsFromTimingUseCase,
            ITryGetStageCarStarsUseCase tryGetStageCarStarsUseCase,
            ISetStageCarStarsUseCase setStageCarStarsUseCase
            )
        {
            GetStageStarsFromTimingUseCase = getStageStarsFromTimingUseCase;
            TryGetStageCarStarsUseCase = tryGetStageCarStarsUseCase;
            SetStageCarStarsUseCase = setStageCarStarsUseCase;
        }
    }
}
