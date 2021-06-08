using Playground.Content.Stage.VisualLogic.View.Car;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class CarViewRepository
    {
        private CarView carView;

        public void Set(CarView carView)
        {
            this.carView = carView;
        }

        public CarView Get()
        {
            return carView;
        }
    }
}
