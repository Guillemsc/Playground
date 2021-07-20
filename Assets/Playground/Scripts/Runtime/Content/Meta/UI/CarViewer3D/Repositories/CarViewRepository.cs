using Juce.Core.Disposables;
using Playground.Content.Stage.VisualLogic.View.Car;

namespace Playground.Content.Meta.UI.CarViewer3D
{
    public class CarViewRepository
    {
        public IDisposable<CarView> Item { get; private set; }

        public void Set(IDisposable<CarView> item)
        {
            Item = item;
        }

        public void Remove()
        {
            Item = null;
        }

        public bool HasItem()
        {
            return Item!= null;
        }
    }
}
