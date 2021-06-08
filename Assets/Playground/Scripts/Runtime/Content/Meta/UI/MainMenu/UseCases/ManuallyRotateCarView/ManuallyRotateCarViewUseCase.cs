using Playground.Content.Stage.VisualLogic.Viewer3D;
using UnityEngine;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class ManuallyRotateCarViewUseCase : IManuallyRotateCarViewUseCase
    {
        private readonly Viewer3DView carViewer3DView;
        private readonly Canvas parentCanvas;

        public ManuallyRotateCarViewUseCase(
            Viewer3DView carViewer3DView,
            Canvas parentCanvas
            )
        {
            this.carViewer3DView = carViewer3DView;
            this.parentCanvas = parentCanvas;
        }

        public void Execute(float ammount)
        {
            float ammountOfRotation = (ammount / parentCanvas.scaleFactor) * 0.5f;

            carViewer3DView.Pivot.localRotation = carViewer3DView.Pivot.localRotation * Quaternion.Euler(0, ammountOfRotation, 0);
        }
    }
}
