using Juce.Core.Loading;
using Playground.Content.LoadingScreen.UI;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Contexts.LoadingScreen.UseCases.Show
{
    public class ShowUseCase : IShowUseCase
    {
        private readonly LoadingScreenUIView loadingScreenUIView;

        public ShowUseCase(
            LoadingScreenUIView loadingScreenUIView
            )
        {
            this.loadingScreenUIView = loadingScreenUIView;
        }

        public async Task<ILoadingToken> Execute()
        {
            await loadingScreenUIView.Show(
                instantly: false,
                cancellationToken: default
                );

            GC.Collect();

            ILoadingToken loadingToken = new CallbackLoadingToken(
                () => loadingScreenUIView.Hide(instantly: false)
                );

            return loadingToken;
        }
    }
}
