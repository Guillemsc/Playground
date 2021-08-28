using Playground.Content.LoadingScreen.UI;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases.ShowLoadingScreen
{
    public interface IShowLoadingScreenUseCase
    {
        Task<ILoadingToken> Execute();
    }
}
