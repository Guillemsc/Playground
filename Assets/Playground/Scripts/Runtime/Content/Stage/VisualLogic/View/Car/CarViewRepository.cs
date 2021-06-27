namespace Playground.Content.Stage.VisualLogic.View.Car
{
    public class CarViewRepository 
    {
        public CarView Item { get; private set; }

        public void Set(CarView item)
        {
            Item = item;
        }

        public bool HasItem()
        {
            return Item != null;
        }
    }
}
