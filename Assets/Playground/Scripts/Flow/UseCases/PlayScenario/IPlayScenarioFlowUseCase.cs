using Playground.Content.LoadingScreen.UI;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public interface IPlayScenarioFlowUseCase
    {
        Task Execute(ILoadingToken loadingToken);
    }
}
