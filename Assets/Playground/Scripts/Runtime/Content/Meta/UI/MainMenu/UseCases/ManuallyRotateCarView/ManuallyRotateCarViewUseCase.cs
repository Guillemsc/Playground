using Playground.Configuration.MainMenu;
using UnityEngine;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class ManuallyRotateCarViewUseCase : IManuallyRotateCarViewUseCase
    {
        private readonly MainMenuConfiguration mainMenuConfiguration;
        private readonly CarViewRotationData carViewRotationData;
        private readonly IScreenToCanvasDeltaUseCase screenToCanvasDeltaUseCase;
        private readonly IRotateCarViewUseCase rotateCarViewUseCase;

        public ManuallyRotateCarViewUseCase(
            MainMenuConfiguration mainMenuConfiguration,
            CarViewRotationData carViewRotationData,
            IScreenToCanvasDeltaUseCase screenToCanvasDeltaUseCase,
            IRotateCarViewUseCase rotateCarViewUseCase
            )
        {
            this.mainMenuConfiguration = mainMenuConfiguration;
            this.carViewRotationData = carViewRotationData;
            this.screenToCanvasDeltaUseCase = screenToCanvasDeltaUseCase;
            this.rotateCarViewUseCase = rotateCarViewUseCase;
        }

        public void Execute(float ammount)
        {
            float canvasAmmount = screenToCanvasDeltaUseCase.Execute(ammount) * mainMenuConfiguration.ManualRotationMultiplier;

            rotateCarViewUseCase.Execute(canvasAmmount);
        }
    }
}
