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
        [SerializeField] private TMPro.TextMeshProUGUI currentPointsText = default;
        [SerializeField] private TMPro.TextMeshProUGUI bestPointsText = default;
        [SerializeField] private TMPro.TextMeshProUGUI currentCoinsText = default;

        private StageEndUIViewModel viewModel;

        private void Awake()
        {
            playAgainPointerCallbacks.OnClick += OnPlayAgainPointerCallbacksClick;
        }

        public void Init(StageEndUIViewModel viewModel)
        {
            this.viewModel = viewModel;

            viewModel.BestPointsVariable.OnChange += (string value) =>
            {
                bestPointsText.text = value;
            };

            viewModel.CurrentPointsVariable.OnChange += (string value) =>
            {
                currentPointsText.text = value;
            };
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
