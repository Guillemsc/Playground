using Playground.Content.Stage.VisualLogic.Tickables;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetPointGoalsTickablesActive
{
    public class SetPointGoalsTickablesActiveUseCase : ISetPointGoalsTickablesActiveUseCase
    {
        private readonly GeneratePointGoalsTickable generatePointGoalsTickable;
        private readonly CleanPointGoalsTickable cleanPointGoalsTickable;

        public SetPointGoalsTickablesActiveUseCase(
            GeneratePointGoalsTickable generatePointGoalsTickable,
            CleanPointGoalsTickable cleanPointGoalsTickable
            )
        {
            this.generatePointGoalsTickable = generatePointGoalsTickable;
            this.cleanPointGoalsTickable = cleanPointGoalsTickable;
        }

        public void Execute(bool active)
        {
            generatePointGoalsTickable.Active = active;
            cleanPointGoalsTickable.Active = active;
        }
    }
}
