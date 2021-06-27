using UnityEngine;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class ScreenToCanvasDeltaUseCase : IScreenToCanvasDeltaUseCase
    {
        private readonly Canvas parentCanvas;

        public ScreenToCanvasDeltaUseCase(Canvas parentCanvas)
        {
            this.parentCanvas = parentCanvas;
        }

        public float Execute(float value)
        {
            if(parentCanvas.scaleFactor <= 0)
            {
                return 0.0f;
            }

            return value / parentCanvas.scaleFactor;
        }
    }
}
