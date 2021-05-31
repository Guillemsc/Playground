﻿using Juce.CoreUnity.Service;
using Playground.Content.StageUI.UI.StageOverlay.UseCases;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.StageUI.UI.StageOverlay
{
    [RequireComponent(typeof(StageOverlayUIView))]
    public class StageOverlayUIInstaller : MonoBehaviour
    {
        private UIViewStackService uiViewStackService;

        private StageOverlayUIViewModel viewModel;
        private StageOverlayUIView view;
        private StageOverlayUIUseCases useCases;
        private StageOverlayUIController controller;
        private StageOverlayUIInteractor interactor;

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
        }

        private void GenerateDependences()
        {
            viewModel = new StageOverlayUIViewModel();
        }

        private void GenerateUseCases()
        {
            IRestartSelectedUseCase restartSelectedUseCase = new RestartSelectedUseCase(
                viewModel
                );

            ISettingsSelectedUseCase settingsSelectedUseCase = new SettingsSelectedUseCase(
                uiViewStackService
                );

            useCases = new StageOverlayUIUseCases(
                restartSelectedUseCase,
                settingsSelectedUseCase
                );
        }

        private void Install()
        {
            view = GetComponent<StageOverlayUIView>();

            controller = new StageOverlayUIController(viewModel, useCases);
            interactor = new StageOverlayUIInteractor(viewModel, useCases);

            view.Init(viewModel);

            controller.Subscribe();
            interactor.Subscribe();

            uiViewStackService.Register(interactor, view);
        }

        private void Uninstall()
        {
            controller.Unsubscribe();
            interactor.Unsubscribe();

            uiViewStackService.Unregister(interactor, view);
        }
    }
}
