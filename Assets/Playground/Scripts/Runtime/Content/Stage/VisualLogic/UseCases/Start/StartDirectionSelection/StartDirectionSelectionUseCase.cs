using Playground.Content.Stage.VisualLogic.Tickables;

namespace Playground.Content.Stage.VisualLogic.UseCases.StartDirectionSelection
{
    public class StartDirectionSelectionUseCase : IStartDirectionSelectionUseCase
    {
        private readonly DirectionSelectionValueTickable directionSelectionValueTickable;

        public StartDirectionSelectionUseCase(
            DirectionSelectionValueTickable directionSelectionValueTickable
            )
        {
            this.directionSelectionValueTickable = directionSelectionValueTickable;
        }

        public void Execute()
        {
            directionSelectionValueTickable.Active = true;
        }
    }
}
