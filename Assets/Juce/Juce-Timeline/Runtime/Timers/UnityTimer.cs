using System;
using System.Threading;
using System.Threading.Tasks;

namespace Juce.CoreUnity.Time
{
    public class UnityTimer
    {
        private bool started;
        private float startTime;

        public TimeSpan Time
        {
            get
            {
                if (!started)
                {
                    return TimeSpan.Zero;
                }

                return TimeSpan.FromSeconds(UnityEngine.Time.realtimeSinceStartup - startTime);
            }
        }

        public void Start(TimeSpan time)
        {
            if (started)
            {
                return;
            }

            started = true;

            startTime = UnityEngine.Time.realtimeSinceStartup - (float)time.TotalSeconds;
        }

        public void Reset()
        {
            started = false;

            startTime = 0.0f;
        }

        public void Restart()
        {
            Reset();
            Start(TimeSpan.Zero);
        }

        public bool HasReached(TimeSpan time)
        {
            if (!started)
            {
                return false;
            }

            return Time >= time;
        }

        public async Task AwaitReach(TimeSpan time, CancellationToken cancellationToken)
        {
            while (!HasReached(time) && !cancellationToken.IsCancellationRequested)
            {
                await Task.Yield();
            }
        }
    }
}