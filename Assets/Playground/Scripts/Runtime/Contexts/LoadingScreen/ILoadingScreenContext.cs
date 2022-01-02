using Juce.Core.Loading;
using System.Threading.Tasks;

namespace Playground.Contexts.LoadingScreen
{
    public interface ILoadingScreenContext 
    {
        Task<ILoadingToken> Show();
    }
}
