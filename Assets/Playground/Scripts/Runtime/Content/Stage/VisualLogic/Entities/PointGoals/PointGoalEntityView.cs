using Juce.TweenPlayer;
using System.Threading;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class PointGoalEntityView : MonoBehaviour
    {
        [SerializeField] private TweenPlayer collectedTween = default;

        public int PointIndex { get; private set; }

        public void Init(int pointIndex)
        {
            PointIndex = pointIndex;
        }

        public void SetCollected()
        {
            collectedTween.Play(CancellationToken.None).RunAsync();
        }
    }
}
