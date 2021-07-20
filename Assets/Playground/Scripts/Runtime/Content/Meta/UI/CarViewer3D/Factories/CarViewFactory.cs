using Juce.Core.Disposables;
using Playground.Configuration.Car;
using Playground.Content.Stage.VisualLogic.View.Car;

namespace Playground.Content.Meta.UI.CarViewer3D
{
    public class CarViewFactory
    {
        public IDisposable<CarView> Create(CarConfiguration carConfiguration)
        {
            CarView carViewInstance = carConfiguration.CarViewPrefab.InstantiateGameObjectAndGetComponent();
            carViewInstance.DisablePhysics();
            carViewInstance.SetSteering(20);

            return new Disposable<CarView>(carViewInstance, Dispose);
        }

        private void Dispose(CarView carView)
        {
            carView.DestroyGameObject();
        }
    }
}
