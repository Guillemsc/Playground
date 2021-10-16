using Juce.TweenPlayer;
using Playground.Configuration.Stage;
using System.Threading;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class EffectEntityView : MonoBehaviour
    {
        [Header("Tweens")]
        [SerializeField] private TweenPlayer despawnTween = default;

        [Header("Configuration")]
        [SerializeField] private EffectConfiguration effectConfiguration = default;

        public EffectConfiguration EffectConfiguration => effectConfiguration;

        public void Despawn()
        {
            despawnTween.Play(CancellationToken.None).RunAsync();
        }
    }
}
