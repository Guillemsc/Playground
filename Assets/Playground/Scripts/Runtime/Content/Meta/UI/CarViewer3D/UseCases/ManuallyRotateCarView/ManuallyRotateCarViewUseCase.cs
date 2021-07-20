using Playground.Configuration.MainMenu;
using UnityEngine;

namespace Playground.Content.Meta.UI.CarViewer3D
{
    public class ManuallyRotateCarViewUseCase : IManuallyRotateCarViewUseCase
    {
        private readonly CarViewer3DConfiguration carViewer3DConfiguration;
        private readonly IScreenToCanvasDeltaUseCase screenToCanvasDeltaUseCase;
        private readonly IRotateCarViewUseCase rotateCarViewUseCase;

        public ManuallyRotateCarViewUseCase(
            CarViewer3DConfiguration carViewer3DConfiguration,
            IScreenToCanvasDeltaUseCase screenToCanvasDeltaUseCase,
            IRotateCarViewUseCase rotateCarViewUseCase
            )
        {
            this.carViewer3DConfiguration = carViewer3DConfiguration;
            this.screenToCanvasDeltaUseCase = screenToCanvasDeltaUseCase;
            this.rotateCarViewUseCase = rotateCarViewUseCase;
        }

        public void Execute(float ammount)
        {
            float canvasAmmount = screenToCanvasDeltaUseCase.Execute(ammount) * carViewer3DConfiguration.ManualRotationMultiplier;

            rotateCarViewUseCase.Execute(canvasAmmount);
        }
    }
}
