using Playground.Configuration.Car;
using Playground.Libraries.Car;

namespace Playground.Content.Meta.UI.CarsLibrary
{
    public class SpawnCarsUseCase : ISpawnCarsUseCase
    {
        private readonly CarLibrary carLibrary;
        private readonly ISpawnCarUseCase spawnCarUseCase;

        public SpawnCarsUseCase(
            CarLibrary carLibrary,
            ISpawnCarUseCase spawnCarUseCase
            )
        {
            this.carLibrary = carLibrary;
            this.spawnCarUseCase = spawnCarUseCase;
        }

        public void Execute()
        {
            foreach(CarConfiguration carConfiguration in carLibrary.Items)
            {
                spawnCarUseCase.Execute(carConfiguration);
            }
        }
    }
}
