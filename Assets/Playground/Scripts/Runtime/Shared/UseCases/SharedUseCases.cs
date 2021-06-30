namespace Playground.Shared.UseCases
{
    public class SharedUseCases
    {
        public ISaveProgressUseCase SaveProgressUseCase { get; }
        public IGetStageStarsFromTimingUseCase GetStageStarsFromTimingUseCase { get; }
        public ITryGetStageCarStarsUseCase TryGetStageCarStarsUseCase { get; }
        public ISetStageCarStarsUseCase SetStageCarStarsUseCase { get; }
        public IAddSoftCurrencyUseCase AddSoftCurrencyUseCase { get; }


        public SharedUseCases(
            ISaveProgressUseCase saveProgressUseCase,
            IGetStageStarsFromTimingUseCase getStageStarsFromTimingUseCase,
            ITryGetStageCarStarsUseCase tryGetStageCarStarsUseCase,
            ISetStageCarStarsUseCase setStageCarStarsUseCase,
            IAddSoftCurrencyUseCase addSoftCurrencyUseCase
            )
        {
            SaveProgressUseCase = saveProgressUseCase;
            GetStageStarsFromTimingUseCase = getStageStarsFromTimingUseCase;
            TryGetStageCarStarsUseCase = tryGetStageCarStarsUseCase;
            SetStageCarStarsUseCase = setStageCarStarsUseCase;
            AddSoftCurrencyUseCase = addSoftCurrencyUseCase;
        }
    }
}
