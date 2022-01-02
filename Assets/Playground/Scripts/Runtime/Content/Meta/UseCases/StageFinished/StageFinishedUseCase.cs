using Juce.CoreUnity.Service;
using Playground.Content.Meta.UI.StageEnd;
using Playground.Content.Stage.UseCases.StageFinished;
using Playground.Services.ViewStack;
using System.Threading;

namespace Playground.Content.Meta.UseCases.StageEnd
{
    public class StageFinishedUseCase : IStageFinishedUseCase
    {
        public void Execute(int currentPoints)
        {
            //UIViewStackService uiViewStackService = ServicesProvider.GetService<UIViewStackService>();

            //IStageEndUIInteractor stageEndInteractor = uiViewStackService.GetInteractor<IStageEndUIInteractor>();

            //stageEndInteractor.Init(currentPoints);

            //uiViewStackService.New().Show<StageEndUIView>(instantly: false)
            //    .Execute(CancellationToken.None).RunAsync();
        }
    }
}
