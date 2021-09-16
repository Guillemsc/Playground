using Juce.Core.State;
using Playground.Content.Stage.Logic.UseCases;

namespace Playground.Content.Stage.Logic.StateMachine
{
    public class SetupStateMachineAction : IStateMachineStateAction<LogicState>
    {
        private readonly UseCaseRepository useCaseRepository;

        public SetupStateMachineAction(
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
            useCaseRepository.SetupStageUseCase.Execute();

            stateMachine.SetNextState(LogicState.Main);
        }
    }
}
