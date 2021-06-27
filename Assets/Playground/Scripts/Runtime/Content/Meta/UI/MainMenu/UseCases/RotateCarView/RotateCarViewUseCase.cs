using Playground.Content.Stage.VisualLogic.Viewer3D;
using UnityEngine;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class RotateCarViewUseCase : IRotateCarViewUseCase
    {
        private readonly Viewer3DView carViewer3DView;

        public RotateCarViewUseCase(
            Viewer3DView carViewer3DView
            )
        {
            this.carViewer3DView = carViewer3DView;
        }

        public void Execute(float ammount)
        {
            float ammountOfRotation = ammount * 0.5f;

            carViewer3DView.Pivot.localRotation = carViewer3DView.Pivot.localRotation * Quaternion.Euler(0, ammountOfRotation, 0);
        }
    }
}
