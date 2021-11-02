using Juce.TweenPlayer;
using System.Threading;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class CoinEntityView : MonoBehaviour
    {
        [Header("Tweens")]
        [SerializeField] private TweenPlayer despawnTween = default;

        public void Despawn()
        {
            despawnTween.Play(CancellationToken.None).RunAsync();
        }

    }
}
