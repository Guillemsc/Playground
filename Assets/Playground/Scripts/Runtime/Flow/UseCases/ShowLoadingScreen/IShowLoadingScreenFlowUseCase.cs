using Playground.Content.LoadingScreen.UI;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public interface IShowLoadingScreenFlowUseCase
    {
        Task<ILoadingToken> Execute(bool instantly);
    }
}
