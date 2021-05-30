using Juce.Core.Time;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class WaitTimeInstruction
    {
        private readonly ITimeContext timeContext;
        private readonly TimeSpan timeSpan;

        public WaitTimeInstruction(
            ITimeContext timeContext,
            TimeSpan timeSpan
            )
        {
            this.timeContext = timeContext;
            this.timeSpan = timeSpan;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            ITimer timer = timeContext.NewTimer();

            timer.Start();

            while (!timer.HasReached(timeSpan) && !cancellationToken.IsCancellationRequested)
            {
                await Task.Yield();
            }
        }
    }
}
