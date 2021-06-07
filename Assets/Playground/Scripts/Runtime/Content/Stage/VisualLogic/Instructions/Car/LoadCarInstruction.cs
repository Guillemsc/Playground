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

        public void Execute()
        {
            CarView instance = carLibrary.Items[0].CarViewPrefab.InstantiateGameObjectAndGetComponent();

            carViewRepository.CarView = instance;
        }
    }
}
