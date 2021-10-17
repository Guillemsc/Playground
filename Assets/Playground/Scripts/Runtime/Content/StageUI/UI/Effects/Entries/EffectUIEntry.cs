using Juce.TweenPlayer;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Playground.Content.StageUI.UI.Effects.Entries
{
    public class EffectUIEntry : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Image backgroundImage = default;
        [SerializeField] private Image iconImage = default;

        [Header("Tweens")]
        [SerializeField] private TweenPlayer showTween = default;
        [SerializeField] private TweenPlayer hideTween = default;

        public void Init(
            Sprite backgroundSprite,
            Sprite iconSprite
            )
        {
            backgroundImage.sprite = backgroundSprite;
            iconImage.sprite = iconSprite;
        }

        public Task SetVisible(bool visible, bool instantly, CancellationToken cancellationToken)
        {
            if(visible)
            {
                return showTween.Play(instantly, cancellationToken);
            }

            return hideTween.Play(instantly, cancellationToken);
        }
    }
}
