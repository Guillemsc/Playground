using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Playground.Utils.UIAnimations
{
    public class UIView : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private bool hideOnAwake = default;

        [Header("Animations")]
        [SerializeField] private UIViewAnimation showAnimation = default;
        [SerializeField] private UIViewAnimation hideAnimation = default;

        private void Awake()
        {
            TryHideOnAwake();
        }

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

        private void TryHideOnAwake()
        {
            if(!hideOnAwake)
            {
                return;
            }

            Hide(instantly: true, default);
        }
    }
}
