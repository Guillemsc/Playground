using Juce.Core.Loading;
using System.Threading.Tasks;

namespace Playground.Contexts.LoadingScreen.UseCases.Show
{
    public interface IShowUseCase
    {
        Task<ILoadingToken> Execute();
    }
}
