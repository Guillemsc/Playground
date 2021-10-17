using Juce.TweenPlayer;
using Playground.Configuration.Stage;
using System.Threading;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class EffectEntityView : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private SpriteRenderer background = default;
        [SerializeField] private SpriteRenderer icon = default;

        [Header("Tweens")]
        [SerializeField] private TweenPlayer despawnTween = default;

        [Header("Configuration")]
        [SerializeField] private EffectConfiguration effectConfiguration = default;

        public SpriteRenderer Background => background;
        public SpriteRenderer Icon => icon;

        public EffectConfiguration EffectConfiguration => effectConfiguration;

        public void Despawn()
        {
            despawnTween.Play(CancellationToken.None).RunAsync();
        }
    }
}
