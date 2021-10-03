using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Service;
using Playground.Content.Meta.UI.StageEnd;
using Playground.Content.Stage.Setup;
using Playground.Contexts.Meta;
using Playground.Contexts.Stage;
using Playground.Flow.UseCases.State;
using Playground.Services.ViewStack;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases.LoadStage
{
    public class LoadStageUseCase : ILoadStageUseCase
    {
        private readonly LastLoadedStageSetupState lastLoadedStageSetupState;

        public LoadStageUseCase(
            LastLoadedStageSetupState lastLoadedStageSetupState
            )
        {
            this.lastLoadedStageSetupState = lastLoadedStageSetupState;
        }

        public Task Execute(StageSetup stageSetup)
        {
            MetaContext metaContext = ContextsProvider.GetContext<MetaContext>();
            StageContext stageContext = ContextsProvider.GetContext<StageContext>();

            UIViewStackService uiViewStackService = ServicesProvider.GetService<UIViewStackService>();

            lastLoadedStageSetupState.StageSetup = stageSetup;

            stageContext.OnStageFinished += () =>
            { 
                uiViewStackService.New().Show<StageEndUIView>(instantly: false).Execute(CancellationToken.None).RunAsync(); 
            };

            return stageContext.LoadStage(stageSetup);
        }
    }
}
