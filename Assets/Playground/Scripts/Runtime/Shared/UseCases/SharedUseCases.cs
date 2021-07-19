namespace Playground.Shared.UseCases
{
    public class SharedUseCases
    {
        public ISaveProgressUseCase SaveProgressUseCase { get; }
        public IGetOwnedCarsUseCase GetOwnedCarsUseCase { get; }
        public IGetStageStarsFromTimingUseCase GetStageStarsFromTimingUseCase { get; }
        public ITryGetStageCarStarsUseCase TryGetStageCarStarsUseCase { get; }
        public ISetStageCarStarsUseCase SetStageCarStarsUseCase { get; }
        public IAddSoftCurrencyUseCase AddSoftCurrencyUseCase { get; }
        public IRemoveSoftCurrencyUseCase RemoveSoftCurrencyUseCase { get; }

        public SharedUseCases(
            ISaveProgressUseCase saveProgressUseCase,
            IGetOwnedCarsUseCase getOwnedCarsUseCase,
            IGetStageStarsFromTimingUseCase getStageStarsFromTimingUseCase,
            ITryGetStageCarStarsUseCase tryGetStageCarStarsUseCase,
            ISetStageCarStarsUseCase setStageCarStarsUseCase,
            IAddSoftCurrencyUseCase addSoftCurrencyUseCase,
            IRemoveSoftCurrencyUseCase removeSoftCurrencyUseCase
            )
        {
            SaveProgressUseCase = saveProgressUseCase;
            GetOwnedCarsUseCase = getOwnedCarsUseCase;
            GetStageStarsFromTimingUseCase = getStageStarsFromTimingUseCase;
            TryGetStageCarStarsUseCase = tryGetStageCarStarsUseCase;
            SetStageCarStarsUseCase = setStageCarStarsUseCase;
            AddSoftCurrencyUseCase = addSoftCurrencyUseCase;
            RemoveSoftCurrencyUseCase = removeSoftCurrencyUseCase;
        }
    }
}
