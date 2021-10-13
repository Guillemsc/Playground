using Juce.Core.DI.Builder;
using Juce.Core.DI.Extensions;
using Juce.Core.DI.Installers;
using JuceUnity.Core.DI.Extensions;
using Playground.Content.StageUI.UI.ActionInputDetection.UseCases.SetDirectionSelectionPosition;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.StageUI.UI.DirectionSelector
{
    [RequireComponent(typeof(DirectionSelectorUIView))]
    public class DirectionSelectorUIInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private RectTransform avaliableDirectionSpace = default;

        public void Install(IDIContainerBuilder container)
        {
            container.Bind<DirectionSelectorUIViewModel>().FromNew();

            container.Bind<DirectionSelectorUIView>()
                .FromGameObject(gameObject)
                .WhenInit((c, o) => o.Init(c.Resolve<DirectionSelectorUIViewModel>()))
                .WhenInit((c, o) => c.Resolve<UIViewStackService>().Register(
                    c.Resolve<IDirectionSelectorUIInteractor>(),
                    o
                    ))
                .WhenDispose((c, o) => c.Resolve<UIViewStackService>().Unregister(o))
                .LinkSubscribable()
                .NonLazy();

            container.Bind(InstallUseCases);

            container.Bind<DirectionSelectorUIController>()
                .FromFunction(c => new DirectionSelectorUIController(
                    c.Resolve<DirectionSelectorUIViewModel>()
                    ))
                .LinkSubscribable()
                .NonLazy();

            container.Bind<IDirectionSelectorUIInteractor, DirectionSelectorUIInteractor>()
                .FromFunction(c => new DirectionSelectorUIInteractor(
                    c.Resolve<DirectionSelectorUIViewModel>(),
                    c.Resolve<ISetDirectionSelectionPositionUseCase>()
                    ))
                .LinkSubscribable()
                .NonLazy();
        }

        private void InstallUseCases(IDIContainerBuilder container)
        {
            container.Bind<ISetDirectionSelectionPositionUseCase>()
                .FromFunction(c => new SetDirectionSelectionPositionUseCase(
                    c.Resolve<DirectionSelectorUIViewModel>(),
                    avaliableDirectionSpace
                    ));
        }
    }
}
