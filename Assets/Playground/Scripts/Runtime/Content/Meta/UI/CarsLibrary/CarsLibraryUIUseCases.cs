namespace Playground.Content.Meta.UI.CarsLibrary
{
    public class CarsLibraryUIUseCases
    {
        public ISpawnCarUseCase SpawnCarUseCase { get; }
        public ISpawnCarsUseCase SpawnCarsUseCase { get; }
        public IRefreshCarsUseCase RefreshCarsUseCase { get; }
        public ICarSelectedUseCase CarSelectedUseCase { get; }

        public CarsLibraryUIUseCases(
            ISpawnCarUseCase spawnCarUseCase,
            ISpawnCarsUseCase spawnCarsUseCase,
            IRefreshCarsUseCase refreshCarsUseCase,
            ICarSelectedUseCase carSelectedUseCase
            )
        {
            SpawnCarUseCase = spawnCarUseCase;
            SpawnCarsUseCase = spawnCarsUseCase;
            RefreshCarsUseCase = refreshCarsUseCase;
            CarSelectedUseCase = carSelectedUseCase;
        }
    }
}
