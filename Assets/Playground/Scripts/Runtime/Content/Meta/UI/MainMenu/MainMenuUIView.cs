using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.UI;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class MainMenuUIView : UIView
    {
        //[Header("References")]
        //[SerializeField] private PointerCallbacks shopPointerCallbacks = default;
        //[SerializeField] private PointerCallbacks carLibraryPointerCallbacks = default;
        //[SerializeField] private PointerCallbacks demoStagesPointerCallbacks = default;
        //[SerializeField] private PointerCallbacks creditsPointerCallbacks = default;
        //[SerializeField] private TMPro.TextMeshProUGUI versionText = default;
        //[SerializeField] private TMPro.TextMeshProUGUI starsText = default;
        //[SerializeField] private TMPro.TextMeshProUGUI softCurrencyText = default;

        //private MainMenuUIViewModel viewModel;
        //private MainMenuUIUseCases useCases;

        //private void Awake()
        //{
        //    Contract.IsNotNull(shopPointerCallbacks, this);
        //    Contract.IsNotNull(carLibraryPointerCallbacks, this);
        //    Contract.IsNotNull(demoStagesPointerCallbacks, this);
        //    Contract.IsNotNull(creditsPointerCallbacks, this);
        //    Contract.IsNotNull(versionText, this);
        //    Contract.IsNotNull(starsText, this);
        //    Contract.IsNotNull(softCurrencyText, this);

        //    //carViewerDragPointerCallbacks.OnBegin += OnCarViewerDragPointerCallbacksBegin;
        //    //carViewerDragPointerCallbacks.OnDragging += OnCarViewerDragPointerCallbacksDragging;
        //    //carViewerDragPointerCallbacks.OnEnd += OnCarViewerDragPointerCallbacksEnd;
        //    shopPointerCallbacks.OnClick += OnShopPointerCallbacksClick;
        //    carLibraryPointerCallbacks.OnClick += OnCarLibraryPointerCallbacksClick;
        //    demoStagesPointerCallbacks.OnClick += OnDemoStagesPointerCallbacksClick;
        //    creditsPointerCallbacks.OnClick += OnCreditsPointerCallbacksClick;
        //}

        //private void OnDestroy()
        //{
        //    //carViewerDragPointerCallbacks.OnBegin -= OnCarViewerDragPointerCallbacksBegin;
        //    //carViewerDragPointerCallbacks.OnDragging -= OnCarViewerDragPointerCallbacksDragging;
        //    //carViewerDragPointerCallbacks.OnEnd -= OnCarViewerDragPointerCallbacksEnd;
        //    shopPointerCallbacks.OnClick -= OnShopPointerCallbacksClick;
        //    carLibraryPointerCallbacks.OnClick -= OnCarLibraryPointerCallbacksClick;
        //    demoStagesPointerCallbacks.OnClick -= OnDemoStagesPointerCallbacksClick;
        //    creditsPointerCallbacks.OnClick -= OnCreditsPointerCallbacksClick;
        //}

        //public void Init(MainMenuUIViewModel viewModel, MainMenuUIUseCases useCases)
        //{
        //    this.viewModel = viewModel;
        //    this.useCases = useCases;

        //    viewModel.StarsVariable.OnChange += (int value) =>
        //    {
        //        starsText.text = value.ToString();
        //    };

        //    viewModel.SoftCurrencyVariable.OnChange += (int value) =>
        //    {
        //        softCurrencyText.text = value.ToString();
        //    };

        //    viewModel.VersionValiable.OnChange += (string value) =>
        //    {
        //        versionText.text = value;
        //    };
        //}

        ////private void OnCarViewerDragPointerCallbacksBegin(DragPointerCallbacks dragPointerCallbacks, PointerEventData pointerEventData)
        ////{
        ////    viewModel.OnStartDraggingCarViewEvent.Execute(dragPointerCallbacks, pointerEventData);
        ////}

        ////private void OnCarViewerDragPointerCallbacksDragging(DragPointerCallbacks dragPointerCallbacks, PointerEventData pointerEventData)
        ////{
        ////    viewModel.OnDragCarViewEvent.Execute(dragPointerCallbacks, pointerEventData);
        ////}

        ////private void OnCarViewerDragPointerCallbacksEnd(DragPointerCallbacks dragPointerCallbacks, PointerEventData pointerEventData)
        ////{
        ////    viewModel.OnStopDraggingCarViewEvent.Execute(dragPointerCallbacks, pointerEventData);
        ////}

        //private void OnShopPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        //{
        //    viewModel.OnShopClickedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        //}

        //private void OnCarLibraryPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        //{
        //    viewModel.OnCarLibraryClickedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        //}

        //private void OnDemoStagesPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        //{
        //    viewModel.OnDemoStagesClickedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        //}

        //private void OnCreditsPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        //{
        //    viewModel.OnCreditsClickedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        //}
    }
}
