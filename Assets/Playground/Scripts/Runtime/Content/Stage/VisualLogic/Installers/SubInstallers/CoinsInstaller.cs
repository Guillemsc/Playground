using Juce.Core.DI.Builder;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.UseCases.CoinsChanged;
using Playground.Content.StageUI.UI.Coins;

namespace Playground.Content.Stage.VisualLogic.Installers
{
    public static class CoinsInstaller
    {
        public static void InstallCoins(
            this IDIContainerBuilder container
            )
        {
            container.Bind<IFactory<CoinEntityViewDefinition, IDisposable<CoinEntityView>>>()
                .FromFunction(c => new CoinEntityViewFactory());

            container.Bind<ICoinsChangedUseCase>()
                .FromFunction(c => new CoinsChangedUseCase(
                    c.Resolve<ICoinsUIInteractor>()
                    ));
        }
    }
}
