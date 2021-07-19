using Juce.Core.Disposables;
using Juce.Core.Observables;
using Juce.CoreUnity.PointerCallback;
using Playground.Configuration.Car;
using UnityEngine;

namespace Playground.Content.Meta.UI.Shop
{
    public class ShopCarUIEntryFactory
    {
        private readonly Transform shopCarUIEntriesParent;
        private readonly ShopCarUIEntry shopCarUIEntryPrefab;
        private readonly ObservableEvent<ShopCarUIEntry, PointerCallbacks> onShopCarClickedEvent;

        public ShopCarUIEntryFactory(
            Transform shopCarUIEntriesParent,
            ShopCarUIEntry shopCarUIEntryPrefab,
            ObservableEvent<ShopCarUIEntry, PointerCallbacks> onShopCarClickedEvent
            )
        {
            this.shopCarUIEntriesParent = shopCarUIEntriesParent;
            this.shopCarUIEntryPrefab = shopCarUIEntryPrefab;
            this.onShopCarClickedEvent = onShopCarClickedEvent;
        }

        public IDisposable<ShopCarUIEntry> Create(CarConfiguration carConfiguration)
        {
            ShopCarUIEntry instance = shopCarUIEntryPrefab.InstantiateGameObjectAndGetComponent(
                shopCarUIEntriesParent
                );

            instance.OnClicked += OnCarLibraryUIEntryClicked;

            instance.Init(carConfiguration);

            return new Disposable<ShopCarUIEntry>(instance, Dispose);
        }

        private void Dispose(ShopCarUIEntry instance)
        {
            instance.OnClicked -= OnCarLibraryUIEntryClicked;

            instance.DestroyGameObject();
        }

        private void OnCarLibraryUIEntryClicked(ShopCarUIEntry shopCarUIEntry, PointerCallbacks pointerCallbacks)
        {
            onShopCarClickedEvent.Execute(shopCarUIEntry, pointerCallbacks);
        }
    }
}
