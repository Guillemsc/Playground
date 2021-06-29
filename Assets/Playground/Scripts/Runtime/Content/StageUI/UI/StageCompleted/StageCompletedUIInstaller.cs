﻿using Juce.CoreUnity.Service;
using Juce.TweenPlayer;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.StageUI.UI.StageCompleted
{
    [RequireComponent(typeof(StageCompletedUIView))]
    public class StageCompletedUIInstaller : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private StageCompletedStarUIEntry stageCompletedStar1UIEntry = default;
        [SerializeField] private StageCompletedStarUIEntry stageCompletedStar2UIEntry = default;
        [SerializeField] private StageCompletedStarUIEntry stageCompletedStar3UIEntry = default;

        [Header("Feedbacks")]
        [SerializeField] private TweenPlayer softCurrencyFeedback = default;

        private UIViewStackService uiViewStackService;

        private StageCompletedUIViewModel viewModel;
        private StageCompletedUIView view;
        private StageCompletedUIUseCases useCases;
        private StageCompletedUIController controller;
        private StageCompletedUIInteractor interactor;

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
            viewModel = new StageCompletedUIViewModel();
        }

        private void GenerateUseCases()
        {
            IShowStarsUseCase showStarsUseCase = new ShowStarsUseCase(
                stageCompletedStar1UIEntry,
                stageCompletedStar2UIEntry,
                stageCompletedStar3UIEntry
                );

            ISetTimeUseCase setTimeUseCase = new SetTimeUseCase(
                viewModel
                );

            IAnimateSoftCurrencyUseCase animateSoftCurrencyUseCase = new AnimateSoftCurrencyUseCase(
                softCurrencyFeedback
                );

            IContinueUseCase continueUseCase = new ContinueUseCase(
                viewModel
                );

            IPlayAgainUseCase playAgainUseCase = new PlayAgainUseCase(
                viewModel
                );

            useCases = new StageCompletedUIUseCases(
                showStarsUseCase,
                setTimeUseCase,
                animateSoftCurrencyUseCase,
                continueUseCase,
                playAgainUseCase
                );
        }

        private void Install()
        {
            view = GetComponent<StageCompletedUIView>();

            controller = new StageCompletedUIController(viewModel, useCases);
            interactor = new StageCompletedUIInteractor(viewModel, useCases);

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
