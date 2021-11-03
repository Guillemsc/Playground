using Juce.Core.DI.Builder;
using Juce.Core.DI.Extensions;
using Juce.Core.DI.Installers;
using Juce.TweenPlayer;
using JuceUnity.Core.DI.Extensions;
using Playground.Content.StageUI.UI.Coins.UseCases.SetPoints;
using UnityEngine;

namespace Playground.Content.StageUI.UI.Coins
{
    [RequireComponent(typeof(CoinsUIView))]
    public class CoinsUIInstaller : MonoBehaviour, IInstaller
    {
        [Header("References")]
        [SerializeField] private TweenPlayer changeCoinsTween = default;

        public void Install(IDIContainerBuilder container)
        {
            container.Bind<CoinsUIViewModel>().FromNew();

            container.Bind<CoinsUIView>()
                .FromGameObject(gameObject)
                .WhenInit((c, o) => o.Init(c.Resolve<CoinsUIViewModel>()))
                .NonLazy();

            container.Bind(InstallUseCases);

            container.Bind<CoinsUIController>()
                .FromFunction(c => new CoinsUIController(
                    c.Resolve<CoinsUIViewModel>()
                    ))
                .LinkSubscribable()
                .NonLazy();

            container.Bind<ICoinsUIInteractor, CoinsUIInteractor>()
                .FromFunction(c => new CoinsUIInteractor(
                    c.Resolve<CoinsUIViewModel>(),
                    c.Resolve<ISetCoinsUseCase>()
                    ))
                .LinkSubscribable()
                .NonLazy();
        }

        private void InstallUseCases(IDIContainerBuilder container)
        {
            container.Bind<ISetCoinsUseCase>()
                .FromFunction(c => new SetCoinsUseCase(
                    changeCoinsTween
                    ));
        }
    }
}
