using Playground.Content.Stage.VisualLogic.UseCases.InputActionReceived;
using Playground.Content.Stage.VisualLogic.UseCases.SetupStage;
using Playground.Content.Stage.VisualLogic.UseCases.StartStage;

namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class UseCaseRepository
    {
        public ISetupStageUseCase SetupStageUseCase { get; }
        public IStartStageUseCase StartStageUseCase { get; }
        public IInputActionReceivedUseCase InputActionReceivedUseCase { get; }

        public UseCaseRepository(
            ISetupStageUseCase setupStageUseCase,
            IStartStageUseCase startStageUseCase,
            IInputActionReceivedUseCase inputActionReceivedUseCase
            )
        {
            SetupStageUseCase = setupStageUseCase;
            StartStageUseCase = startStageUseCase;
            InputActionReceivedUseCase = inputActionReceivedUseCase;
        }
    }
}
