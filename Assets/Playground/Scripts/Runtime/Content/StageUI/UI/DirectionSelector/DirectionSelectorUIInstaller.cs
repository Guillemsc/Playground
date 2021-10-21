using Juce.Core.DI.Builder;
using Juce.Core.DI.Extensions;
using Juce.Core.DI.Installers;
using Juce.TweenPlayer;
using JuceUnity.Core.DI.Extensions;
using Playground.Content.StageUI.UI.ActionInputDetection.UseCases.GetAnchoredFromNormalizedPosition;
using Playground.Content.StageUI.UI.ActionInputDetection.UseCases.SetCurrentSelectedPosition;
using Playground.Content.StageUI.UI.ActionInputDetection.UseCases.SetDirectionSelectionPosition;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.StageUI.UI.DirectionSelector
{
    [RequireComponent(typeof(DirectionSelectorUIView))]
    public class DirectionSelectorUIInstaller : MonoBehaviour, IInstaller
    {
        [Header("References")]
        [SerializeField] private RectTransform avaliableDirectionSpace = default;

        [Header("Tweens")]
        [SerializeField] private TweenPlayer currentDirectionSelectedTween = default;
        [SerializeField] private TweenPlayer changeCurrentDirectionMarkerTween = default;

        public void Install(IDIContainerBuilder container)
        {
            container.Bind<DirectionSelectorUIViewModel>().FromNew();

            container.Bind<DirectionSelectorUIView>()
                .FromGameObject(gameObject)
                .WhenInit((c, o) => o.Init(c.Resolve<DirectionSelectorUIViewModel>()))
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
                    c.Resolve<ISetDirectionSelectionPositionUseCase>(),
                    c.Resolve<ISetCurrentSelectedPositionUseCase>()
                    ))
                .LinkSubscribable()
                .NonLazy();
        }

        private void InstallUseCases(IDIContainerBuilder container)
        {
            container.Bind<IGetAnchoredFromNormalizedPositionUseCase>()
                .FromFunction(c => new GetAnchoredFromNormalizedPositionUseCase(
                    avaliableDirectionSpace
                    ));

            container.Bind<ISetDirectionSelectionPositionUseCase>()
                .FromFunction(c => new SetDirectionSelectionPositionUseCase(
                    c.Resolve<DirectionSelectorUIViewModel>(),
                    c.Resolve<IGetAnchoredFromNormalizedPositionUseCase>()
                    ));

            container.Bind<ISetCurrentSelectedPositionUseCase>()
                .FromFunction(c => new SetCurrentSelectedPositionUseCase(
                    currentDirectionSelectedTween,
                    changeCurrentDirectionMarkerTween,
                    c.Resolve<IGetAnchoredFromNormalizedPositionUseCase>()
                    ));
        }
    }
}
