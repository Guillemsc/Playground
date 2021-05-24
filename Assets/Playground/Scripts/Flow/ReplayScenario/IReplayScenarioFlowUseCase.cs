using Playground.Content.LoadingScreen.UI;
using System;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public interface IReplayScenarioFlowUseCase
    {
        Task Execute(ILoadingToken loadingToken);
    }
}
