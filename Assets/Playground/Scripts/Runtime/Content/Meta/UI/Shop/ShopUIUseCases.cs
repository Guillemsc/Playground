namespace Playground.Content.Meta.UI.Shop
{
    public class ShopUIUseCases
    {
        public ISpawnCarUseCase SpawnCarUseCase { get; }
        public ISpawnCarsUseCase SpawnCarsUseCase { get; }
        public ICarSelectedUseCase CarSelectedUseCase { get; }

        public ShopUIUseCases(
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
