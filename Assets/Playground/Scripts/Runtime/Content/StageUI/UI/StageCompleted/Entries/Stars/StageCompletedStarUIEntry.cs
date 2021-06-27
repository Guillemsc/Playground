using Juce.TweenPlayer;
using UnityEngine;

namespace Playground.Content.StageUI.UI.StageCompleted
{
    public class StageCompletedStarUIEntry : MonoBehaviour
    {
        [SerializeField] private TweenPlayer showEarnedFeedback = default;
        [SerializeField] private TweenPlayer showNotEarnedFeedback = default;

        public TweenPlayer ShowEarnedFeedback => showEarnedFeedback;
        public TweenPlayer ShowNotEarnedFeedback => showNotEarnedFeedback;
    }
}
