using Juce.Core.State;
using Playground.Content.Stage.Logic.UseCases;
using Playground.Content.Stage.Logic.UseCases.SetupStage;

namespace Playground.Content.Stage.Logic.StateMachine
{
    public class SetupStateMachineAction : IStateMachineStateAction<LogicState>
    {
        private readonly ISetupStageUseCase setupStageUseCase;

        public SetupStateMachineAction(
            ISetupStageUseCase setupStageUseCase
            )
        {
            this.setupStageUseCase = setupStageUseCase;
        }

        public void OnEnter()
        {
      
        }

        public void OnExit()
        {
         
        }

        public void OnRun(IStateMachine<LogicState> stateMachine)
        {
            setupStageUseCase.Execute();

            stateMachine.SetNextState(LogicState.WaitForStart);
        }
    }
}
