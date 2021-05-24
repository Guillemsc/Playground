using Juce.Core.Events.Generic;
using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.Service;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.VisualLogic.View.Signals;
using Playground.Services;
using Playground.Utils.UIAnimations;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.StageUI.UI.StageCompleted
{
    public class StageCompletedUIView : UIView
    {
        [Header("References")]
        [SerializeField] private PointerCallbacks tryAgainPointerCallbacks = default;

        private GenericSignal<StageCompletedUIView, EventArgs> canUnloadStageSignal;

        protected override void OnAwake()
        {
            Contract.IsNotNull(tryAgainPointerCallbacks, this);

            tryAgainPointerCallbacks.OnClick += OnTryAgainPointerCallbacksClick;
        }

        private void OnDestroy()
        {
            tryAgainPointerCallbacks.OnClick -= OnTryAgainPointerCallbacksClick;
        }

        public void Init(GenericSignal<StageCompletedUIView, EventArgs> canUnloadStageSignal)
        {
            this.canUnloadStageSignal = canUnloadStageSignal;
        }

        private void OnTryAgainPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            PlayAgain().RunAsync();
        }

        private async Task PlayAgain()
        {
            FlowService flowService = ServicesProvider.GetService<FlowService>();

            ILoadingToken loadingToken = await flowService.FlowUseCases.ShowLoadingScreenFlowUseCase.Execute(instantly: false);

            canUnloadStageSignal.Trigger(this, EventArgs.Empty);

            await flowService.FlowUseCases.ReplayScenarioFlowUseCase.Execute(loadingToken);
        }
    }
}
