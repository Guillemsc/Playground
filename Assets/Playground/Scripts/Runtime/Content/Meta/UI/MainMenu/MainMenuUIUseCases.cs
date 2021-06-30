namespace Playground.Content.Meta.UI.MainMenu
{
    public class MainMenuUIUseCases
    {
        public IScreenToCanvasDeltaUseCase ScreenToCanvasDeltaUseCase { get; }
        public ICleanUpCarViewUseCase CleanUpCarViewUseCase { get; }
        public IShowCarViewUseCase ShowCarViewUseCase { get; }
        public IRotateCarViewUseCase RotateCarViewUseCase { get; }
        public IStartManuallyRotatingCarViewUseCase StartManuallyRotatingCarViewUseCase { get; }
        public IStopManuallyRotatingCarViewUseCase StopManuallyRotatingCarViewUseCase { get; }
        public IManuallyRotateCarViewUseCase ManuallyRotate3DCarUseCase { get; }
        public ICarryCarViewRotationVelocityTickableUseCase CarryCarViewRotationVelocityTickableUseCase { get; }
        public IRefreshStarsUseCase RefreshStarsUseCase { get; }
        public IRefreshSoftCurrencyUseCase RefreshSoftCurrencyUseCase { get; }

        public MainMenuUIUseCases(
            IScreenToCanvasDeltaUseCase screenToCanvasDeltaUseCase,
            ICleanUpCarViewUseCase cleanUpCarViewUseCase,
            IShowCarViewUseCase showCarViewUseCase,
            IRotateCarViewUseCase rotateCarViewUseCase,
            IStartManuallyRotatingCarViewUseCase startManuallyRotatingCarViewUseCase,
            IStopManuallyRotatingCarViewUseCase stopManuallyRotatingCarViewUseCase,
            IManuallyRotateCarViewUseCase manuallyRotate3DCarUseCase,
            ICarryCarViewRotationVelocityTickableUseCase carryCarViewRotationVelocityTickableUseCase,
            IRefreshStarsUseCase refreshStarsUseCase,
            IRefreshSoftCurrencyUseCase refreshSoftCurrencyUseCase
            )
        {
            ScreenToCanvasDeltaUseCase = screenToCanvasDeltaUseCase;
            CleanUpCarViewUseCase = cleanUpCarViewUseCase;
            ShowCarViewUseCase = showCarViewUseCase;
            RotateCarViewUseCase = rotateCarViewUseCase;
            StartManuallyRotatingCarViewUseCase = startManuallyRotatingCarViewUseCase;
            StopManuallyRotatingCarViewUseCase = stopManuallyRotatingCarViewUseCase;
            ManuallyRotate3DCarUseCase = manuallyRotate3DCarUseCase;
            CarryCarViewRotationVelocityTickableUseCase = carryCarViewRotationVelocityTickableUseCase;
            RefreshStarsUseCase = refreshStarsUseCase;
            RefreshSoftCurrencyUseCase = refreshSoftCurrencyUseCase;
        }
    }
}
