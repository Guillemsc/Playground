using Juce.Core.Tickable;
using Playground.Content.Stage.VisualLogic.UseCases.CleanPointGoals;

namespace Playground.Content.Stage.VisualLogic.Tickables
{
    public class CleanPointGoalsTickable : ActivableTickable
    {
        private readonly ICleanPointGoalsUseCase cleanPointGoalsUseCase;

        public CleanPointGoalsTickable(ICleanPointGoalsUseCase cleanPointGoalsUseCase) : base(active: false)
        {
            this.cleanPointGoalsUseCase = cleanPointGoalsUseCase;
        }

        protected override void ActivableTick()
        {
            cleanPointGoalsUseCase.Execute();
        }
    }
}
