using Juce.CoreUnity.PointerCallback;
using Playground.Content.Meta.UI.Credits;
using Playground.Services.ViewStack;
using System;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class MainMenuUIController 
    {
        //private readonly MainMenuUIViewModel viewModel;
        //private readonly MainMenuUIUseCases useCases;
        //private readonly UIViewStackService uiViewStackService;

        //public MainMenuUIController(
        //    MainMenuUIViewModel viewModel,
        //    MainMenuUIUseCases useCases,
        //    UIViewStackService uiViewStackService
        //    )
        //{
        //    this.viewModel = viewModel;
        //    this.useCases = useCases;
        //    this.uiViewStackService = uiViewStackService;
        //}

        //public void Subscribe()
        //{
        //    viewModel.OnShopClickedEvent.OnExecute += OnShopClickedEvent;
        //    viewModel.OnCarLibraryClickedEvent.OnExecute += OnCarLibraryClickedEvent;
        //    viewModel.OnDemoStagesClickedEvent.OnExecute += OnDemoStagesClickedEvent;
        //    viewModel.OnCreditsClickedEvent.OnExecute += OnCreditsClickedEvent;
        //}

        //public void Unsubscribe()
        //{
        //    viewModel.OnShopClickedEvent.OnExecute -= OnShopClickedEvent;
        //    viewModel.OnCarLibraryClickedEvent.OnExecute -= OnCarLibraryClickedEvent;
        //    viewModel.OnDemoStagesClickedEvent.OnExecute -= OnDemoStagesClickedEvent;
        //    viewModel.OnCreditsClickedEvent.OnExecute -= OnCreditsClickedEvent;
        //}

        //private void OnShopClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        //{
        //    uiViewStackService.New().Show<ShopUIView>(instantly: false).HideAndPush<MainMenuUIView>(instantly: true).Execute();
        //}

        //private void OnCarLibraryClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        //{
        //    uiViewStackService.New().Show<CarsLibraryUIView>(instantly: false).HideAndPush<MainMenuUIView>(instantly: true).Execute();
        //}

        //private void OnDemoStagesClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        //{
        //    uiViewStackService.New().Show<DemoStagesUIView>(instantly: false).HideAndPush<MainMenuUIView>(instantly: true).Execute();
        //}

        //private void OnCreditsClickedEvent(PointerCallbacks pointerCallbacks, EventArgs eventArgs)
        //{
        //    uiViewStackService.New().Show<CreditsUIView>(instantly: false).HideAndPush<MainMenuUIView>(instantly: true).Execute();
        //}
    }
}
