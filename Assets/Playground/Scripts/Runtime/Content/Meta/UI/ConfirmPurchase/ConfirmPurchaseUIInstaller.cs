using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.Service;
using Playground.Services;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.Meta.UI.ConfirmPurchase
{
    [RequireComponent(typeof(ConfirmPurchaseUIView))]
    public class ConfirmPurchaseUIInstaller : MonoBehaviour
    {
        private UIViewStackService uiViewStackService;
        private ConfigurationService configurationService;
        private PersistenceService userService;

        private EventsData eventsData;

        private ConfirmPurchaseUIViewModel viewModel;
        private ConfirmPurchaseUIView view;
        private ConfirmPurchaseUIUseCases useCases;
        private ConfirmPurchaseUIController controller;
        private ConfirmPurchaseUIInteractor interactor;

        private void Start()
        {
            GatherDependences();
            GenerateDependences();
            GenerateUseCases();
            Install();
        }

        private void OnDestroy()
        {
            Uninstall();
        }

        private void GatherDependences()
        {
            uiViewStackService = ServicesProvider.GetService<UIViewStackService>();
            configurationService = ServicesProvider.GetService<ConfigurationService>();
            userService = ServicesProvider.GetService<PersistenceService>();
        }

        private void GenerateDependences()
        {
            eventsData = new EventsData();

            viewModel = new ConfirmPurchaseUIViewModel();
        }

        private void GenerateUseCases()
        {
            ISetupDataUseCase setupDataUseCase = new SetupDataUseCase(
                viewModel
                );

            IPurchasedUseCase purchaseCaseUseCase = new PurchasedUseCase(
                eventsData
                );

            useCases = new ConfirmPurchaseUIUseCases(
                setupDataUseCase,
                purchaseCaseUseCase
                );
        }

        private void Install()
        {
            view = GetComponent<ConfirmPurchaseUIView>();

            controller = new ConfirmPurchaseUIController(viewModel, useCases);
            interactor = new ConfirmPurchaseUIInteractor(viewModel, useCases, eventsData);

            view.Init(viewModel);

            controller.Subscribe();
            interactor.Subscribe();

            uiViewStackService.Register(interactor, view);
        }

        private void Uninstall()
        {
            controller.Unsubscribe();
            interactor.Unsubscribe();

            uiViewStackService.Unregister(view);
        }
    }
}
