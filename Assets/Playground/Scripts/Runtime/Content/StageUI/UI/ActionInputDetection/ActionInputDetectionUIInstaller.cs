using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using JuceUnity.Core.DI.Extensions;
using Playground.Content.StageUI.UI.ActionInputDetection.UseCases;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.StageUI.UI.ActionInputDetection
{
    [RequireComponent(typeof(ActionInputDetectionUIView))]
    public class ActionInputDetectionUIInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IDIContainerBuilder container)
        {
            container.Bind<ActionInputDetectionUIViewModel>().FromNew();
            container.Bind<ActionInputDetectionUIEvents>().FromNew();

            container.Bind<ActionInputDetectionUIView>()
                .FromGameObject(gameObject)
                .WhenInit((c, o) => o.Init(c.Resolve<ActionInputDetectionUIViewModel>()))
                .WhenInit((c, o) => c.Resolve<UIViewStackService>().Register(
                    c.Resolve<IActionInputDetectionUIInteractor>(), 
                    o
                    ))
                .WhenDispose((c, o) => c.Resolve<UIViewStackService>().Unregister(o))
                .NonLazy();

            container.Bind(InstallUseCases);

            container.Bind<ActionInputDetectionUIController>()
                .FromFunction((c) => new ActionInputDetectionUIController(
                    c.Resolve<ActionInputDetectionUIViewModel>(),
                    c.Resolve<IInputActionReceivedUseCase>()
                    ))
                .WhenInit((c, o) => o.Subscribe())
                .WhenDispose((o) => o.Unsubscribe())
                .NonLazy(); 

            container.Bind<IActionInputDetectionUIInteractor, ActionInputDetectionUIInteractor>()
                .FromFunction((c) => new ActionInputDetectionUIInteractor(
                    c.Resolve<ActionInputDetectionUIViewModel>(),
                    c.Resolve<ActionInputDetectionUIEvents>()
                    ))
                .WhenInit((c, o) => o.Subscribe())
                .WhenDispose((o) => o.Unsubscribe())
                .NonLazy();
        }

        private void InstallUseCases(IDIContainerBuilder container)
        {
            container.Bind<IInputActionReceivedUseCase>()
                .FromFunction((c) => new InputActionReceivedUseCase(
                    c.Resolve<ActionInputDetectionUIEvents>()
                    ));
        }
    }
}
