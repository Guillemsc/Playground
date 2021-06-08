namespace Playground.Content.Meta.UI.MainMenu
{
    public class MainMenuUIUseCases
    {
        public IShowCarViewUseCase Show3DCarUseCase { get; }
        public IManuallyRotateCarViewUseCase ManuallyRotate3DCarUseCase { get; }

        public MainMenuUIUseCases(
            IShowCarViewUseCase show3DCarUseCase,
            IManuallyRotateCarViewUseCase manuallyRotate3DCarUseCase
            )
        {
            Show3DCarUseCase = show3DCarUseCase;
            ManuallyRotate3DCarUseCase = manuallyRotate3DCarUseCase;
        }
    }
}
