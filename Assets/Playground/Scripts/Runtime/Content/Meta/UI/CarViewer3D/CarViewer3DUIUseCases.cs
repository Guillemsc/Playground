namespace Playground.Content.Meta.UI.CarViewer3D
{
    public class CarViewer3DUIUseCases
    {
        public ICleanUpCarViewUseCase CleanUpCarViewUseCase { get; }
        public IShowCarViewUseCase ShowCarViewUseCase { get; }
        public IRotateCarViewUseCase RotateCarViewUseCase { get; }
        public IStartManuallyRotatingCarViewUseCase StartManuallyRotatingCarViewUseCase { get; }
        public IStopManuallyRotatingCarViewUseCase StopManuallyRotatingCarViewUseCase { get; }
        public IManuallyRotateCarViewUseCase ManuallyRotate3DCarUseCase { get; }
        public ICarryCarViewRotationVelocityTickableUseCase CarryCarViewRotationVelocityTickableUseCase { get; }

        public CarViewer3DUIUseCases(
            ICleanUpCarViewUseCase cleanUpCarViewUseCase,
            IShowCarViewUseCase showCarViewUseCase,
            IRotateCarViewUseCase rotateCarViewUseCase,
            IStartManuallyRotatingCarViewUseCase startManuallyRotatingCarViewUseCase,
            IStopManuallyRotatingCarViewUseCase stopManuallyRotatingCarViewUseCase,
            IManuallyRotateCarViewUseCase manuallyRotate3DCarUseCase,
            ICarryCarViewRotationVelocityTickableUseCase carryCarViewRotationVelocityTickableUseCase
            )
        {
            CleanUpCarViewUseCase = cleanUpCarViewUseCase;
            ShowCarViewUseCase = showCarViewUseCase;
            RotateCarViewUseCase = rotateCarViewUseCase;
            StartManuallyRotatingCarViewUseCase = startManuallyRotatingCarViewUseCase;
            StopManuallyRotatingCarViewUseCase = stopManuallyRotatingCarViewUseCase;
            ManuallyRotate3DCarUseCase = manuallyRotate3DCarUseCase;
            CarryCarViewRotationVelocityTickableUseCase = carryCarViewRotationVelocityTickableUseCase;
        }
    }
}
