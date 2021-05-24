using Juce.CoreUnity.Contexts;
using Playground.Content.LoadingScreen.UI;
using Playground.Contexts;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class ShowLoadingScreenFlowUseCase : IShowLoadingScreenFlowUseCase
    {
        public async Task<ILoadingToken> Execute(bool instantly)
        {
            LoadingScreenContext loadingScreenContext = ContextsProvider.GetContext<LoadingScreenContext>();

            await loadingScreenContext.LoadingScreenContextReferences.LoadingScreenUIView.Show(instantly, cancellationToken: default);

            ILoadingToken loadingToken = new CallbackLoadingToken(
                () => loadingScreenContext.LoadingScreenContextReferences.LoadingScreenUIView.Hide(instantly: false)
                );

            return loadingToken;
        }
    }
}
