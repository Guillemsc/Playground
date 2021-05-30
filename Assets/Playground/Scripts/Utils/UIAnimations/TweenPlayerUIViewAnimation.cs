using Juce.CoreUnity.UI;
using Juce.TweenPlayer;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Playground.Utils.UIAnimations
{
    public class TweenPlayerUIViewAnimation : UIViewAnimation
    {
        [Header("Settings")]
        [SerializeField] private bool executeInstantlyOnAwake = default;

        [Header("Feedbacks")]
        [SerializeField] private List<TweenPlayer> tweenPlayersToPlay = default;
        [SerializeField] private List<TweenPlayer> tweenPlayersToKill = default;
        [SerializeField] private List<TweenPlayer> tweenPlayersToComplete = default;

        private void Awake()
        {
            TryExecuteInstantlyOnAwake();
        }

        private void TryExecuteInstantlyOnAwake()
        {
            if(!executeInstantlyOnAwake)
            {
                return;
            }

            Execute(instantly: true, default).RunAsync();
        }

        public override Task Execute(bool instantly, CancellationToken cancellationToken)
        {
            foreach(TweenPlayer tweenPlayer in tweenPlayersToComplete)
            {
                if(tweenPlayer == null)
                {
                    UnityEngine.Debug.LogError($"Null {nameof(TweenPlayer) }at {nameof(TweenPlayerUIViewAnimation)}", this);
                    continue;
                }

                tweenPlayer.Complete();
            }

            foreach (TweenPlayer tweenPlayer in tweenPlayersToKill)
            {
                if (tweenPlayer == null)
                {
                    UnityEngine.Debug.LogError($"Null {nameof(TweenPlayer) }at {nameof(TweenPlayerUIViewAnimation)}", this);
                    continue;
                }

                tweenPlayer.Kill();
            }

            List<Task> tasks = new List<Task>();

            for(int i = 0; i < tweenPlayersToPlay.Count; ++i)
            {
                TweenPlayer tweenPlayer = tweenPlayersToPlay[i];

                if (tweenPlayer == null)
                {
                    UnityEngine.Debug.LogError($"Null {nameof(TweenPlayer)} at {nameof(TweenPlayerUIViewAnimation)}", this);
                    continue;
                }

                tasks.Add(tweenPlayer.Play(instantly, cancellationToken));
            }

            return Task.WhenAll(tasks);
        }
    }
}
