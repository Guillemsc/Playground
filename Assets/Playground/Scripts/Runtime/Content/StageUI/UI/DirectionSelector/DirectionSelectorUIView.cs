using Juce.Core.Subscribables;
using Juce.CoreUnity.UI;
using UnityEngine;

namespace Playground.Content.StageUI.UI.DirectionSelector
{
    public class DirectionSelectorUIView : UIView, ISubscribable
    {
        [Header("References")]
        [SerializeField] private RectTransform directionSelectionTransform = default;

        private DirectionSelectorUIViewModel viewModel;

        private void Awake()
        {
           
        }

        public void Init(DirectionSelectorUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public void Subscribe()
        {
            viewModel.DirectionSelectionAnchoredPositionX.OnChange += OnDirectionSelectionAnchoredPositionXChanged;
        }

        public void Unsubscribe()
        {
            viewModel.DirectionSelectionAnchoredPositionX.OnChange -= OnDirectionSelectionAnchoredPositionXChanged;
        }

        private void OnDirectionSelectionAnchoredPositionXChanged(float value)
        {
            directionSelectionTransform.anchoredPosition = new Vector2(
                value,
                directionSelectionTransform.anchoredPosition.y
                );
        }
    }
}
