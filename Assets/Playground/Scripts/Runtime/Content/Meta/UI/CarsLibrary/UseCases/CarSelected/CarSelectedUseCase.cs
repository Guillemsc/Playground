using Juce.Core.Disposables;
using Playground.Services;

namespace Playground.Content.Meta.UI.CarsLibrary
{
    public class CarSelectedUseCase : ICarSelectedUseCase
    {
        private readonly PersistenceService persistenceService;
        private readonly CarLibraryUIEntryRepository carLibraryUIEntryRepository;

        public CarSelectedUseCase(
            PersistenceService persistenceService,
            CarLibraryUIEntryRepository carLibraryUIEntryRepository
            )
        {
            this.persistenceService = persistenceService;
            this.carLibraryUIEntryRepository = carLibraryUIEntryRepository;
        }

        public void Execute(string carTypeId)
        {
            persistenceService.UserDataSerializableData.Data.SelectedCarTypeId = carTypeId;

            persistenceService.UserDataSerializableData.Save(default).RunAsync();

            foreach (IDisposable<CarLibraryUIEntry> entry in carLibraryUIEntryRepository.Items)
            {
                bool isSelectedCar = entry.Value.CarTypeId.Equals(carTypeId);

                entry.Value.SetSelected(isSelectedCar, instantly: false, default).RunAsync();
            }
        }
    }
}
