using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.DragPointerCallback;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.UI;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class MainMenuUIView : UIView
    {
        [Header("References")]
        [SerializeField] private DragPointerCallbacks carViewerDragPointerCallbacks = default;
        [SerializeField] private PointerCallbacks carLibraryPointerCallbacks = default;
        [SerializeField] private PointerCallbacks demoStagesPointerCallbacks = default;
        [SerializeField] private PointerCallbacks creditsPointerCallbacks = default;
        [SerializeField] private TMPro.TextMeshProUGUI versionText = default;

        private MainMenuUIViewModel viewModel;
        private MainMenuUIUseCases useCases;

        private void Awake()
        {
            Contract.IsNotNull(carViewerDragPointerCallbacks, this);
            Contract.IsNotNull(carLibraryPointerCallbacks, this);
            Contract.IsNotNull(demoStagesPointerCallbacks, this);
            Contract.IsNotNull(creditsPointerCallbacks, this);
            Contract.IsNotNull(versionText, this);

            carViewerDragPointerCallbacks.OnDragging += OnCarViewerDragPointerCallbacksDragging;
            carLibraryPointerCallbacks.OnClick += OnCarLibraryPointerCallbacksClick;
            demoStagesPointerCallbacks.OnClick += OnDemoStagesPointerCallbacksClick;
            creditsPointerCallbacks.OnClick += OnCreditsPointerCallbacksClick;
        }

        private void OnDestroy()
        {
            carViewerDragPointerCallbacks.OnDragging -= OnCarViewerDragPointerCallbacksDragging;
            carLibraryPointerCallbacks.OnClick -= OnCarLibraryPointerCallbacksClick;
            demoStagesPointerCallbacks.OnClick -= OnDemoStagesPointerCallbacksClick;
            creditsPointerCallbacks.OnClick -= OnCreditsPointerCallbacksClick;
        }

        public void Init(MainMenuUIViewModel viewModel, MainMenuUIUseCases useCases)
        {
            this.viewModel = viewModel;
            this.useCases = useCases;

            viewModel.VersionValiable.OnChange += (string value) =>
            {
                versionText.text = value;
            };
        }

        private void OnCarViewerDragPointerCallbacksDragging(DragPointerCallbacks dragPointerCallbacks, PointerEventData pointerEventData)
        {
            useCases.ManuallyRotate3DCarUseCase.Execute(-pointerEventData.delta.x);
        }

        private void OnCarLibraryPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.OnCarLibraryClickedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        }

        private void OnDemoStagesPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.OnDemoStagesClickedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        }

        private void OnCreditsPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.OnCreditsClickedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        }
    }
}
