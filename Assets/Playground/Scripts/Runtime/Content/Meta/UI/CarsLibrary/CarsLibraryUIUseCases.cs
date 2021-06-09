namespace Playground.Content.Meta.UI.CarsLibrary
{
    public class CarsLibraryUIUseCases
    {
        public ISpawnCarUseCase SpawnCarUseCase { get; }
        public ISpawnCarsUseCase SpawnCarsUseCase { get; }

        public CarsLibraryUIUseCases(
             ISpawnCarUseCase spawnCarUseCase,
             ISpawnCarsUseCase spawnCarsUseCase
            )
        {
            SpawnCarUseCase = spawnCarUseCase;
            SpawnCarsUseCase = spawnCarsUseCase;
        }
    }
}
