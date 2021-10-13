using Playground.Content.Stage.VisualLogic.State;
using Playground.Content.StageUI.UI.DirectionSelector;

namespace Playground.Content.Stage.VisualLogic.UseCases.ChangeShipDirection
{
    public class ChangeShipDirectionUseCase : IChangeShipDirectionUseCase
    {
        private readonly InputState inputState;
        private readonly DirectionSelectionState directionSelectionState;
        private readonly IDirectionSelectorUIInteractor directionSelectorUIInteractor;

        public ChangeShipDirectionUseCase(
            InputState inputState,
            DirectionSelectionState directionSelectionState,
            IDirectionSelectorUIInteractor directionSelectorUIInteractor
            )
        {
            this.inputState = inputState;
            this.directionSelectionState = directionSelectionState;
            this.directionSelectorUIInteractor = directionSelectorUIInteractor;
        }

        public void Execute()
        {
            if(!inputState.CanChangeShipDirection)
            {
                return;
            }

            directionSelectionState.LastSelectedDirecitonNormalizedValue = directionSelectionState.DirectionSelectionNormalizedValue;

            directionSelectorUIInteractor.SetCurrentSelectedPosition(
                directionSelectionState.LastSelectedDirecitonNormalizedValue
                );
        }
    }
}
