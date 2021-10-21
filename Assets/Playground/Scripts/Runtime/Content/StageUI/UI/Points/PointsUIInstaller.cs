using Juce.Core.DI.Builder;
using Juce.Core.DI.Extensions;
using Juce.Core.DI.Installers;
using Juce.TweenPlayer;
using JuceUnity.Core.DI.Extensions;
using Playground.Content.StageUI.UI.Effects.UseCases.SetPoints;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.StageUI.UI.Points
{
    [RequireComponent(typeof(PointsUIView))]
    public class PointsUIInstaller : MonoBehaviour, IInstaller
    {
        [Header("References")]
        [SerializeField] private TweenPlayer changePointsTween = default;

        public void Install(IDIContainerBuilder container)
        {
            container.Bind<PointsUIViewModel>().FromNew();

            container.Bind<PointsUIView>()
                .FromGameObject(gameObject)
                .WhenInit((c, o) => o.Init(c.Resolve<PointsUIViewModel>()))
                .NonLazy();

            container.Bind(InstallUseCases);

            container.Bind<PointsUIController>()
                .FromFunction(c => new PointsUIController(
                    c.Resolve<PointsUIViewModel>()
                    ))
                .LinkSubscribable()
                .NonLazy();

            container.Bind<IPointsUIInteractor, PointsUIInteractor>()
                .FromFunction(c => new PointsUIInteractor(
                    c.Resolve<PointsUIViewModel>(),
                    c.Resolve<ISetPointsUseCase>()
                    ))
                .LinkSubscribable()
                .NonLazy();
        }

        private void InstallUseCases(IDIContainerBuilder container)
        {
            container.Bind<ISetPointsUseCase>()
                 .FromFunction(c => new SetPointsUseCase(
                     changePointsTween
                     ));
        }
    }
}
