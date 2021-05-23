using Playground.Content.Stage.Libraries;
using Playground.Content.Stage.VisualLogic.View.Car;

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

        public void Execute()
        {
            CarView instance = carLibrary.DefaultCarPrefab.InstantiateGameObjectAndGetComponent();

            carViewRepository.CarView = instance;
        }
    }
}
