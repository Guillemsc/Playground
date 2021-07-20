using Playground.Configuration.MainMenu;
using UnityEngine;

namespace Playground.Content.Meta.UI.CarViewer3D
{
    public class StopManuallyRotatingCarViewUseCase : IStopManuallyRotatingCarViewUseCase
    {
        private readonly CarViewer3DConfiguration carViewer3DConfiguration;
        private readonly CarViewRotationData carViewRotationData;
        private readonly IScreenToCanvasDeltaUseCase screenToCanvasDeltaUseCase;

        public StopManuallyRotatingCarViewUseCase(
            CarViewer3DConfiguration carViewer3DConfiguration,
            CarViewRotationData carViewRotationData,
            IScreenToCanvasDeltaUseCase screenToCanvasDeltaUseCase
            )
        {
            this.carViewer3DConfiguration = carViewer3DConfiguration;
            this.carViewRotationData = carViewRotationData;
            this.screenToCanvasDeltaUseCase = screenToCanvasDeltaUseCase;
        }

        public void Execute(float ammount)
        {
            float canvasAmmount = screenToCanvasDeltaUseCase.Execute(ammount) * carViewer3DConfiguration.ManualRotationMultiplier;

            carViewRotationData.IsManuallyRotating = false;
            carViewRotationData.CurrentCarriedRotationSpeed = canvasAmmount;
            carViewRotationData.CurrentCarriedRotationDecelerationTime = 0.0f;
        }
    }
}
