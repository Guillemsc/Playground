using Juce.Core.Loading;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases.ShowLoadingScreen
{
    public interface IShowLoadingScreenUseCase
    {
        Task<ILoadingToken> Execute();
    }
}
