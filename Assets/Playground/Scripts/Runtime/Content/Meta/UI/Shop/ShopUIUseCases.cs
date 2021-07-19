namespace Playground.Content.Meta.UI.Shop
{
    public class ShopUIUseCases
    {
        public ISpawnCarUseCase SpawnCarUseCase { get; }
        public ISpawnCarsUseCase SpawnCarsUseCase { get; }

        public ShopUIUseCases(
            ISpawnCarUseCase spawnCarUseCase,
            ISpawnCarsUseCase spawnCarsUseCase
            )
        {
            SpawnCarUseCase = spawnCarUseCase;
            SpawnCarsUseCase = spawnCarsUseCase;
        }
    }
}
