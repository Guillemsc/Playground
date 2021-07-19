using Juce.CoreUnity.DragPointerCallback;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.Service;
using Playground.Content.Meta.UI.CarsLibrary;
using Playground.Content.Meta.UI.Credits;
using Playground.Content.Meta.UI.DemoStages;
using Playground.Content.Meta.UI.Shop;
using Playground.Services.ViewStack;
using System;
using UnityEngine.EventSystems;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class MainMenuUIController 
    {
        private readonly MainMenuUIViewModel viewModel;
        private readonly MainMenuUIUseCases useCases;
        private readonly UIViewStackService uiViewStackService;

        public MainMenuUIController(
            MainMenuUIViewModel viewModel,
            MainMenuUIUseCases useCases,
            UIViewStackService uiViewStackService
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
            this.uiViewStackService = uiViewStackService;
        }

        public void Subscribe()
        {
            viewModel.OnStartDraggingCarViewEvent.OnExecute += OnStartDraggingCarViewEvent;
            viewModel.OnStopDraggingCarViewEvent.OnExecute += OnStopDraggingCarViewEvent;
            viewModel.OnDragCarViewEvent.OnExecute += OnDragCarViewEvent;
            viewModel.OnShopClickedEvent.OnExecute += OnShopClickedEvent;
            viewModel.OnCarLibraryClickedEvent.OnExecute += OnCarLibraryClickedEvent;
            viewModel.OnDemoStagesClickedEvent.OnExecute += OnDemoStagesClickedEvent;
            viewModel.OnCreditsClickedEvent.OnExecute += OnCreditsClickedEvent;
        }

        public void Unsubscribe()
        {
            viewModel.OnStartDraggingCarViewEvent.OnExecute -= OnStartDraggingCarViewEvent;
            viewModel.OnStopDraggingCarViewEvent.OnExecute -= OnStopDraggingCarViewEvent;
            viewModel.OnDragCarViewEvent.OnExecute -= OnDragCarViewEvent;
            viewModel.OnShopClickedEvent.OnExecute -= OnShopClickedEvent;
            viewModel.OnCarLibraryClickedEvent.OnExecute -= OnCarLibraryClickedEvent;
            viewModel.OnDemoStagesClickedEvent.OnExecute -= OnDemoStagesClickedEvent;
            viewModel.OnCreditsClickedEvent.OnExecute -= OnCreditsClickedEvent;
        }

        private void OnStartDraggingCarViewEvent(DragPointerCallbacks dragPointerCallbacks, PointerEventData pointerEventData)
        {
            useCases.StartManuallyRotatingCarViewUseCase.Execute();
        }

        private void OnStopDraggingCarViewEvent(DragPointerCallbacks dragPointerCallbacks, PointerEventData pointerEventData)
        {
            useCases.StopManuallyRotatingCarViewUseCase.Execute(-pointerEventData.delta.x);
        }

        private void OnDragCarViewEvent(DragPointerCallbacks dragPointerCallbacks, PointerEventData pointerEventData)
        {
            useCases.ManuallyRotate3DCarUseCase.Execute(-pointerEventData.delta.x);
        }

        private void OnShopClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            uiViewStackService.New().Show<ShopUIView>(instantly: false).Hide<MainMenuUIView>(instantly: true).Execute();
        }

        private void OnCarLibraryClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            uiViewStackService.New().Show<CarsLibraryUIView>(instantly: false).Hide<MainMenuUIView>(instantly: true).Execute();
        }

        private void OnDemoStagesClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            uiViewStackService.New().Show<DemoStagesUIView>(instantly: false).Hide<MainMenuUIView>(instantly: true).Execute();
        }

        private void OnCreditsClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        {
            uiViewStackService.New().Show<CreditsUIView>(instantly: false).Hide<MainMenuUIView>(instantly: true).Execute();
        }
    }
}
