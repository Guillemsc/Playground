using Playground.Configuration.Car;
using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Libraries.Car;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class LoadCarInstruction
    {
        private readonly CarLibrary carLibrary;
        private readonly CarViewRepository carViewRepository;

        public LoadCarInstruction(
            CarLibrary carLibrary,
            CarViewRepository carViewRepository
            )
        {
            this.carLibrary = carLibrary;
            this.carViewRepository = carViewRepository;
        }

        public void Execute(string carTypeId)
        {
            bool found = carLibrary.TryGet(carTypeId, out CarConfiguration carConfiguration);

            if(!found)
            {
                carConfiguration = carLibrary.Items[0];
            }

            CarView instance = carConfiguration.CarViewPrefab.InstantiateGameObjectAndGetComponent();

            carViewRepository.CarView = instance;
        }
    }
}
