using Juce.TweenPlayer;
using UnityEngine;

namespace Playground.Content.StageUI.UI.StageCompleted
{
    public class StageCompletedStarUIEntry : MonoBehaviour
    {
        [SerializeField] private TweenPlayer showActiveFeedback = default;
        [SerializeField] private TweenPlayer showInactiveFeedback = default;

        public TweenPlayer ShowActiveFeedback => showActiveFeedback;
        public TweenPlayer ShowInactiveFeedback => showInactiveFeedback;
    }
}
