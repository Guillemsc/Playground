using Juce.Core.State;
using Playground.Content.Stage.Logic.UseCases;

namespace Playground.Content.Stage.Logic.StateMachine
{
    public class DisposeStateMachineAction : IStateMachineStateAction<LogicState>
    {
        private readonly UseCaseRepository useCaseRepository;

        public DisposeStateMachineAction(
            UseCaseRepository useCaseRepository
            )
        {
            this.useCaseRepository = useCaseRepository;
        }

        public void OnEnter()
        {

        }

        public void OnExit()
        {

        }

        public void OnRun(IStateMachine<LogicState> stateMachine)
        {

        }
    }
}
