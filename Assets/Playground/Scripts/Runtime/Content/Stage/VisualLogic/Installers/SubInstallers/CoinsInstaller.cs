using Juce.Core.DI.Builder;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.State;
using Playground.Content.Stage.VisualLogic.UseCases.CoinsChanged;

namespace Playground.Content.Stage.VisualLogic.Installers
{
    public static class CoinsInstaller
    {
        public static void InstallCoins(
            this IDIContainerBuilder container
            )
        {
            container.Bind<CoinsState>()
                .FromNew();

            container.Bind<IFactory<CoinEntityViewDefinition, IDisposable<CoinEntityView>>>()
                .FromFunction(c => new CoinEntityViewFactory());

            container.Bind<ICoinsChangedUseCase>()
                .FromFunction(c => new CoinsChangedUseCase(
                    c.Resolve<CoinsState>()
                    ));
        }
    }
}
