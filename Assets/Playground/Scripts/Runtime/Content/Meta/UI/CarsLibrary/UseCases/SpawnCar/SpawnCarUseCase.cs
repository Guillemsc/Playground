using Juce.Core.Disposables;
using Playground.Configuration.Car;

namespace Playground.Content.Meta.UI.CarsLibrary
{
    public class SpawnCarUseCase : ISpawnCarUseCase
    {
        private readonly CarLibraryUIEntryFactory carLibraryUIEntryFactory;
        private readonly CarLibraryUIEntryRepository carLibraryUIEntryRepository;

        public SpawnCarUseCase(
            CarLibraryUIEntryFactory carLibraryUIEntryFactory,
            CarLibraryUIEntryRepository carLibraryUIEntryRepository
            )
        {
            this.carLibraryUIEntryFactory = carLibraryUIEntryFactory;
            this.carLibraryUIEntryRepository = carLibraryUIEntryRepository;
        }

        public void Execute(CarConfiguration carConfiguration)
        {
            IDisposable<CarLibraryUIEntry> instance = carLibraryUIEntryFactory.Create(carConfiguration);

            carLibraryUIEntryRepository.Add(instance);
        }
    }
}
