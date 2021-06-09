using Juce.Core.Disposables;
using Juce.Core.Observables;
using Juce.CoreUnity.PointerCallback;
using Playground.Configuration.Car;
using UnityEngine;

namespace Playground.Content.Meta.UI.CarsLibrary
{
    public class CarLibraryUIEntryFactory
    {
        private readonly Transform carLibraryUIEntriesParent;
        private readonly CarLibraryUIEntry carLibraryUIEntryPrefab;
        private readonly ObservableEvent<CarLibraryUIEntry, PointerCallbacks> onCarLibraryClickedEvent;

        public CarLibraryUIEntryFactory(
            Transform carLibraryUIEntriesParent,
            CarLibraryUIEntry carLibraryUIEntryPrefab,
            ObservableEvent<CarLibraryUIEntry, PointerCallbacks> onCarLibraryClickedEvent
            )
        {
            this.carLibraryUIEntriesParent = carLibraryUIEntriesParent;
            this.carLibraryUIEntryPrefab = carLibraryUIEntryPrefab;
            this.onCarLibraryClickedEvent = onCarLibraryClickedEvent;
        }

        public IDisposable<CarLibraryUIEntry> Create(CarConfiguration carConfiguration)
        {
            CarLibraryUIEntry instance = carLibraryUIEntryPrefab.InstantiateGameObjectAndGetComponent(
                carLibraryUIEntriesParent
                );

            instance.OnClicked += OnCarLibraryUIEntryClicked;

            instance.Init(carConfiguration);

            return new Disposable<CarLibraryUIEntry>(instance, Dispose);
        }

        private void Dispose(CarLibraryUIEntry instance)
        {
            instance.OnClicked -= OnCarLibraryUIEntryClicked;

            instance.DestroyGameObject();
        }

        private void OnCarLibraryUIEntryClicked(CarLibraryUIEntry carLibraryUIEntry, PointerCallbacks pointerCallbacks)
        {
            onCarLibraryClickedEvent.Execute(carLibraryUIEntry, pointerCallbacks);
        }
    }
}
