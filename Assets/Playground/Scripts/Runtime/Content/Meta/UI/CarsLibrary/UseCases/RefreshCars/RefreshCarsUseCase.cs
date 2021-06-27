using Juce.Core.Disposables;
using Playground.Services;

namespace Playground.Content.Meta.UI.CarsLibrary
{
    public class RefreshCarsUseCase : IRefreshCarsUseCase
    {
        private readonly PersistenceService persistenceService;
        private readonly CarLibraryUIEntryRepository carLibraryUIEntryRepository;

        public RefreshCarsUseCase(
            PersistenceService persistenceService,
            CarLibraryUIEntryRepository carLibraryUIEntryRepository
            )
        {
            this.persistenceService = persistenceService;
            this.carLibraryUIEntryRepository = carLibraryUIEntryRepository;
        }

        public void Execute()
        {
            string userDataSelectedCarTypeId = persistenceService.UserDataSerializableData.Data.SelectedCarTypeId;

            foreach (IDisposable<CarLibraryUIEntry> entry in carLibraryUIEntryRepository.Items)
            {
                bool isSelectedCar = entry.Value.CarTypeId.Equals(userDataSelectedCarTypeId);

                entry.Value.SetSelected(isSelectedCar, instantly: true, default).RunAsync();
            }
        }
    }
}
