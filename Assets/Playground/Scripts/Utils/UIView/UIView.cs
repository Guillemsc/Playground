using Playground.Utils.UIAnimations;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Playground.Utils.UI
{
    public class UIView : MonoBehaviour
    {
        [Header("Animations")]
        [SerializeField] private UIViewAnimation showAnimation = default;
        [SerializeField] private UIViewAnimation hideAnimation = default;

        public void Show(bool instantly)
        {
            Show(instantly, default).RunAsync();
        }

        public void Hide(bool instantly)
        {
            Hide(instantly, default).RunAsync();
        }

        public Task Show(bool instantly, CancellationToken cancellationToken)
        {
            if(showAnimation == null)
            {
                UnityEngine.Debug.LogError($"Null show {nameof(UIViewAnimation)} at {nameof(UIView)}", this);
                return Task.CompletedTask;
            }

            return showAnimation.Execute(instantly, cancellationToken);
        }

        public Task Hide(bool instantly, CancellationToken cancellationToken)
        {
            if (hideAnimation == null)
            {
                UnityEngine.Debug.LogError($"Null hide {nameof(UIViewAnimation)} at {nameof(UIView)}", this);
                return Task.CompletedTask;
            }

            return hideAnimation.Execute(instantly, cancellationToken);
        }
    }
}
