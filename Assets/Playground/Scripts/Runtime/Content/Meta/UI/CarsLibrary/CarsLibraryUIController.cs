using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.Service;
using Playground.Services.ViewStack;
using System;

namespace Playground.Content.Meta.UI.CarsLibrary
{
    public class CarsLibraryUIController
    {
        private readonly CarsLibraryUIViewModel viewModel;
        private readonly CarsLibraryUIUseCases useCases;

        public CarsLibraryUIController(
            CarsLibraryUIViewModel viewModel,
            CarsLibraryUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Subscribe()
        {
            viewModel.OnBackClickedEvent.OnExecute += OnBackClickedEvent;

            useCases.SpawnCarsUseCase.Execute();
        }

        public void Unsubscribe()
        {
            viewModel.OnBackClickedEvent.OnExecute -= OnBackClickedEvent;
        }

        private void OnBackClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            UIViewStackService uiViewStackService = ServicesProvider.GetService<UIViewStackService>();
            uiViewStackService.New().ShowLast(instantly: false).Hide<CarsLibraryUIView>(instantly: true).Execute();
        }
    }
}
