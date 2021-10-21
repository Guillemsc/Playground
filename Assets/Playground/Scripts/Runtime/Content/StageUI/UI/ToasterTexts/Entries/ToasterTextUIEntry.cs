using Juce.TweenPlayer;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Playground.Content.StageUI.UI.ToasterTexts.Entries
{
    public class ToasterTextUIEntry : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMPro.TextMeshProUGUI text = default;

        [Header("Tweens")]
        [SerializeField] private TweenPlayer showAndHideTween = default;

        public void Init(string text)
        {
            this.text.text = text;
        }

        public Task Play(CancellationToken cancellationToken)
        {
            return showAndHideTween.Play(cancellationToken);
        }
    }
}
