using Playground.Content.LoadingScreen.UI;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public interface ILoadMetaFlowUseCase
    {
        Task Execute(ILoadingToken loadingToken);
    }
}
