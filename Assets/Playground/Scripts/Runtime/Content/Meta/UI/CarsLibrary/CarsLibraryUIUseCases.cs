namespace Playground.Content.Meta.UI.CarsLibrary
{
    public class CarsLibraryUIUseCases
    {
        public ISpawnCarUseCase SpawnCarUseCase { get; }
        public ISpawnCarsUseCase SpawnCarsUseCase { get; }
        public ICarSelectedUseCase CarSelectedUseCase { get; }

        public CarsLibraryUIUseCases(
            ISpawnCarUseCase spawnCarUseCase,
            ISpawnCarsUseCase spawnCarsUseCase,
            ICarSelectedUseCase carSelectedUseCase
            )
        {
            SpawnCarUseCase = spawnCarUseCase;
            SpawnCarsUseCase = spawnCarsUseCase;
            CarSelectedUseCase = carSelectedUseCase;
        }
    }
}
