using Juce.CoreUnity.Contexts;
using Playground.Content.Stage.Setup;
using Playground.Contexts.Stage;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases.LoadStage
{
    public class LoadStageUseCase : ILoadStageUseCase
    {
        public Task Execute(StageSetup stageSetup)
        {
            StageContext stageContext = ContextsProvider.GetContext<StageContext>();

            return stageContext.LoadStage(stageSetup);
        }
    }
}
