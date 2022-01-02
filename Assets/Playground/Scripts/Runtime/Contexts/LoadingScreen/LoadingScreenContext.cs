using Juce.Core.Loading;
using Playground.Contexts.LoadingScreen.UseCases.Show;
using System.Threading.Tasks;

namespace Playground.Contexts.LoadingScreen
{
    public class LoadingScreenContext : ILoadingScreenContext
    {
        private readonly IShowUseCase showUseCase;

        public LoadingScreenContext(
            IShowUseCase showUseCase
            )
        {
            this.showUseCase = showUseCase;
        }

        public Task<ILoadingToken> Show()
        {
            return showUseCase.Execute();
        }
    }
}
