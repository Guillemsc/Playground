using Juce.Core.Tickable;
using Juce.Core.Time;
using Playground.Content.Stage.VisualLogic.State;
using Playground.Content.Stage.VisualLogic.UseCases.GetDirectionSelectionValue;
using Playground.Content.StageUI.UI.DirectionSelector;

namespace Playground.Content.Stage.VisualLogic.Tickables
{
    public class DirectionSelectionValueTickable : ActivableTickable
    {
        private readonly ITimer timer;
        private readonly DirectionSelectionState directionSelectionData;
        private readonly IDirectionSelectorUIInteractor directionSelectorUIInteractor;
        private readonly IGetDirectionSelectionValueUseCase getDirectionSelectionValueUseCase;

        public DirectionSelectionValueTickable(
            ITimer timer,
            DirectionSelectionState directionSelectionData,
            IDirectionSelectorUIInteractor directionSelectorUIInteractor,
            IGetDirectionSelectionValueUseCase getDirectionSelectionValueUseCase
            ) : base(active: false)
        {
            this.timer = timer;
            this.directionSelectionData = directionSelectionData;
            this.directionSelectorUIInteractor = directionSelectorUIInteractor;
            this.getDirectionSelectionValueUseCase = getDirectionSelectionValueUseCase;

            directionSelectorUIInteractor.SetDirectionSelectionPosition(0.5f);
        }

        protected override void ActivableStart()
        {
            timer.Start();
        }

        protected override void ActivableTick()
        {
            float seconds = (float)timer.Time.TotalSeconds;

            directionSelectionData.DirectionSelectionNormalizedValue = getDirectionSelectionValueUseCase.Execute(seconds);

            directionSelectorUIInteractor.SetDirectionSelectionPosition(
                directionSelectionData.DirectionSelectionNormalizedValue
                );
        }
    }
}
