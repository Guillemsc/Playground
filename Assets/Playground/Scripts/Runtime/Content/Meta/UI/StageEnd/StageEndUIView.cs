using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.Meta.UI.StageEnd
{
    public class StageEndUIView : UIView
    {
        [Header("References")]
        [SerializeField] private PointerCallbacks playAgainPointerCallbacks = default;

        private StageEndUIViewModel viewModel;

        private void Awake()
        {
            playAgainPointerCallbacks.OnClick += OnPlayAgainPointerCallbacksClick;
        }

        public void Init(StageEndUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private void OnPlayAgainPointerCallbacksClick(
            PointerCallbacks pointerCallbacks,
            PointerEventData pointerEventData
            )
        {
            viewModel.OnPlayAgainEvent.Execute(this, pointerEventData);
        }
    }
}
