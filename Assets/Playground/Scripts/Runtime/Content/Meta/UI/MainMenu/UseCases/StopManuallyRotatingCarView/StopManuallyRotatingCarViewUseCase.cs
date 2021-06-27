using Playground.Configuration.MainMenu;
using UnityEngine;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class StopManuallyRotatingCarViewUseCase : IStopManuallyRotatingCarViewUseCase
    {
        private readonly MainMenuConfiguration mainMenuConfiguration;
        private readonly CarViewRotationData carViewRotationData;
        private readonly IScreenToCanvasDeltaUseCase screenToCanvasDeltaUseCase;

        public StopManuallyRotatingCarViewUseCase(
            MainMenuConfiguration mainMenuConfiguration,
            CarViewRotationData carViewRotationData,
            IScreenToCanvasDeltaUseCase screenToCanvasDeltaUseCase
            )
        {
            this.mainMenuConfiguration = mainMenuConfiguration;
            this.carViewRotationData = carViewRotationData;
            this.screenToCanvasDeltaUseCase = screenToCanvasDeltaUseCase;
        }

        public void Execute(float ammount)
        {
            float canvasAmmount = screenToCanvasDeltaUseCase.Execute(ammount) * mainMenuConfiguration.ManualRotationMultiplier;

            carViewRotationData.IsManuallyRotating = false;
            carViewRotationData.CurrentCarriedRotationSpeed = canvasAmmount;
            carViewRotationData.CurrentCarriedRotationDecelerationTime = 0.0f;
        }
    }
}
