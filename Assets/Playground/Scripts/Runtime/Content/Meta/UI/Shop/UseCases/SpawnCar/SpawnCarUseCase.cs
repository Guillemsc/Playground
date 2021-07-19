using Juce.Core.Disposables;
using Playground.Configuration.Car;

namespace Playground.Content.Meta.UI.Shop
{
    public class SpawnCarUseCase : ISpawnCarUseCase
    {
        private readonly ShopCarUIEntryFactory shopCarUIEntryFactory;
        private readonly ShopCarUIEntryRepository shopCarUIEntryRepository;

        public SpawnCarUseCase(
            ShopCarUIEntryFactory shopCarUIEntryFactory,
            ShopCarUIEntryRepository shopCarUIEntryRepository
            )
        {
            this.shopCarUIEntryFactory = shopCarUIEntryFactory;
            this.shopCarUIEntryRepository = shopCarUIEntryRepository;
        }

        public void Execute(CarConfiguration carConfiguration)
        {
            IDisposable<ShopCarUIEntry> instance = shopCarUIEntryFactory.Create(carConfiguration);

            shopCarUIEntryRepository.Add(instance);
        }
    }
}
