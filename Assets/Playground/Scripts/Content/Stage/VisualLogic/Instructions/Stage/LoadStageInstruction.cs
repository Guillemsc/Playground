using Playground.Content.Stage.VisualLogic.View.Stage;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class LoadStageInstruction
    {
        private readonly StageViewRepository stageViewRepository;
        private readonly StageView stageViewPrefab;

        public LoadStageInstruction(
            StageViewRepository stageViewRepository,
            StageView stageViewPrefab
            )
        {
            this.stageViewRepository = stageViewRepository;
            this.stageViewPrefab = stageViewPrefab;
        }

        public void Execute()
        {
            StageView instance = stageViewPrefab.InstantiateGameObjectAndGetComponent();

            stageViewRepository.StageView = instance;
        }
    }
}
