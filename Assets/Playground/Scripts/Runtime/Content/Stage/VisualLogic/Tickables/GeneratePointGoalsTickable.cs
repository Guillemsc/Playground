using Juce.Core.Tickable;
using Playground.Content.Stage.VisualLogic.UseCases.GeneratePointGoals;

namespace Playground.Content.Stage.VisualLogic.Tickables
{
    public class GeneratePointGoalsTickable : ActivableTickable
    {
        private readonly IGeneratePointGoalsUseCase generatePointGoalsUseCase;

        public GeneratePointGoalsTickable(IGeneratePointGoalsUseCase generatePointGoalsUseCase) : base(active: false)
        {
            this.generatePointGoalsUseCase = generatePointGoalsUseCase;
        }

        protected override void ActivableTick()
        {
            generatePointGoalsUseCase.Execute();
        }
    }
}
