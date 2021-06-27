namespace Playground.Content.Meta.UI.MainMenu
{
    public class StartManuallyRotatingCarViewUseCase : IStartManuallyRotatingCarViewUseCase
    {
        private readonly CarViewRotationData carViewRotationData;

        public StartManuallyRotatingCarViewUseCase(
            CarViewRotationData carViewRotationData
            )
        {
            this.carViewRotationData = carViewRotationData;
        }

        public void Execute()
        {
            carViewRotationData.IsManuallyRotating = true;
        }
    }
}
