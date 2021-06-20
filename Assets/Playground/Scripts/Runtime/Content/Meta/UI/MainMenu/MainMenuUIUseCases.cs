namespace Playground.Content.Meta.UI.MainMenu
{
    public class MainMenuUIUseCases
    {
        public ICleanUpCarViewUseCase CleanUpCarViewUseCase { get; }
        public IShowCarViewUseCase Show3DCarUseCase { get; }
        public IManuallyRotateCarViewUseCase ManuallyRotate3DCarUseCase { get; }

        public MainMenuUIUseCases(
            ICleanUpCarViewUseCase cleanUpCarViewUseCase,
            IShowCarViewUseCase show3DCarUseCase,
            IManuallyRotateCarViewUseCase manuallyRotate3DCarUseCase
            )
        {
            CleanUpCarViewUseCase = cleanUpCarViewUseCase;
            Show3DCarUseCase = show3DCarUseCase;
            ManuallyRotate3DCarUseCase = manuallyRotate3DCarUseCase;
        }
    }
}
