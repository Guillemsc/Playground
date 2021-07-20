using Playground.Content.Stage.VisualLogic.Viewer3D;

namespace Playground.Content.Meta.UI.CarViewer3D
{
    public class CleanUpCarViewUseCase : ICleanUpCarViewUseCase
    {
        private readonly CarViewRepository carViewRepository;

        public CleanUpCarViewUseCase(
            CarViewRepository carViewRepository
            )
        {
            this.carViewRepository = carViewRepository;
        }

        public void Execute()
        {
            if(!carViewRepository.HasItem())
            {
                return;
            }

            carViewRepository.Item.Dispose();

            carViewRepository.Remove();
        }
    }
}
