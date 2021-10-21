using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using JuceUnity.Core.DI.Extensions;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.StageUI.UI.MainStageUI
{
    [RequireComponent(typeof(MainStageUIView))]
    public class MainStageUIInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IDIContainerBuilder container)
        {
            container.Bind<MainStageUIView>()
                .FromGameObject(gameObject)
                .WhenInit((c, o) => c.Resolve<UIViewStackService>().Register(
                    c.Resolve<MainStageUIInteractor>(),
                    o
                    ))
                .WhenDispose((c, o) => c.Resolve<UIViewStackService>().Unregister(o))
                .NonLazy();

            container.Bind<MainStageUIInteractor>()
                .FromNew();
        }
    }
}
