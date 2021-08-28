using Juce.CoreUnity.Contexts;
using Playground.Content.LoadingScreen.UI;
using Playground.Contexts.LoadingScreen;
using System;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases.ShowLoadingScreen
{
    public class ShowLoadingScreenUseCase : IShowLoadingScreenUseCase
    {
        public async Task<ILoadingToken> Execute()
        {
            LoadingScreenContext loadingScreenContext = ContextsProvider.GetContext<LoadingScreenContext>();

            await loadingScreenContext.LoadingScreenContextReferences.LoadingScreenUIView.Show(
                instantly: false, 
                cancellationToken: default
                );

            GC.Collect();

            ILoadingToken loadingToken = new CallbackLoadingToken(
                () => loadingScreenContext.LoadingScreenContextReferences.LoadingScreenUIView.Hide(instantly: false)
                );

            return loadingToken;
        }
    }
}
