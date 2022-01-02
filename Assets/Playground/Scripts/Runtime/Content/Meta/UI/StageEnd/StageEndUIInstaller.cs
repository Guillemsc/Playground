using Juce.Core.DI.Builder;
using Juce.Core.DI.Extensions;
using Juce.Core.DI.Installers;
using JuceUnity.Core.DI.Extensions;
using Playground.Content.Meta.UI.StageEnd.UseCases.Init;
using Playground.Content.Meta.UI.StageEnd.UseCases.PlayAgain;
using Playground.Services;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.Meta.UI.StageEnd
{
    [RequireComponent(typeof(StageEndUIView))]
    public class StageEndUIInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IDIContainerBuilder container)
        {
            container.Bind<StageEndUIViewModel>().FromNew();

            container.Bind<StageEndUIView>()
                .FromGameObject(gameObject)
                .WhenInit((c, o) => o.Init(c.Resolve<StageEndUIViewModel>()))
                .WhenInit((c, o) => c.Resolve<UIViewStackService>().Register(
                    c.Resolve<IStageEndUIInteractor>(),
                    o
                    ))
                .WhenDispose((c, o) => c.Resolve<UIViewStackService>().Unregister(o))
                .NonLazy();

            container.Bind(InstallUseCases);

            container.Bind<StageEndUIController>()
                .FromFunction(c => new StageEndUIController(
                    c.Resolve<StageEndUIViewModel>(),
                    c.Resolve<IPlayAgainUseCase>()
                    ))
                .LinkSubscribable()
                .NonLazy();

            container.Bind<IStageEndUIInteractor, StageEndUIInteractor>()
                .FromFunction(c => new StageEndUIInteractor(
                    c.Resolve<StageEndUIViewModel>(),
                    c.Resolve<IInitUseCase>()
                    ))
                .LinkSubscribable()
                .NonLazy();
        }

        private void InstallUseCases(IDIContainerBuilder container)
        {
            container.Bind<IInitUseCase>()
                .FromFunction(c => new InitUseCase(
                    c.Resolve<StageEndUIViewModel>()
                    ));

            container.Bind<IPlayAgainUseCase>()
                .FromFunction(c => new PlayAgainUseCase(
                    c.Resolve<FlowService>(),
                    c.Resolve<UIViewStackService>()
                    ));
        }
    }
}
