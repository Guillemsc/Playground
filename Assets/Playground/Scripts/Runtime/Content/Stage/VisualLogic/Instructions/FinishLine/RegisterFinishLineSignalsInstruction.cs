using Playground.Content.Stage.VisualLogic.View.CheckPoints;
using Playground.Content.Stage.VisualLogic.View.Signals;
using System;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class RegisterFinishLineSignalsInstruction
    {
        private readonly FinishLineView finishLineView;
        private readonly GenericSignal<FinishLineView, EventArgs> finishLineCrossedSignal;

        public RegisterFinishLineSignalsInstruction(
            FinishLineView finishLineView,
            GenericSignal<FinishLineView, EventArgs> finishLineCrossedSignal
            )
        {
            this.finishLineView = finishLineView;
            this.finishLineCrossedSignal = finishLineCrossedSignal;
        }

        public void Execute()
        {
            if(finishLineView == null)
            {
                UnityEngine.Debug.LogError($"Tried to register to {nameof(FinishLineView)} but it was null, " +
                    $"at {nameof(RegisterFinishLineSignalsInstruction)}");

                return;
            }

            finishLineView.OnCrossed += finishLineCrossedSignal.Trigger;
        }
    }
}
