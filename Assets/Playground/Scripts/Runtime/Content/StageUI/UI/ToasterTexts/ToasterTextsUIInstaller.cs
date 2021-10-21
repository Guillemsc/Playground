using Juce.Core.DI.Builder;
using Juce.Core.DI.Extensions;
using Juce.Core.DI.Installers;
using JuceUnity.Core.DI.Extensions;
using UnityEngine;

namespace Playground.Content.StageUI.UI.ToasterTexts
{
    [RequireComponent(typeof(ToasterTextsUIView))]
    public class ToasterTextsUIInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IDIContainerBuilder container)
        {
            container.Bind<ToasterTextsUIViewModel>().FromNew();

            container.Bind<ToasterTextsUIView>()
                .FromGameObject(gameObject)
                .WhenInit((c, o) => o.Init(c.Resolve<ToasterTextsUIViewModel>()))
                .NonLazy();

            container.Bind(InstallUseCases);

            container.Bind<ToasterTextsUIController>()
                .FromFunction(c => new ToasterTextsUIController(
                    c.Resolve<ToasterTextsUIViewModel>()
                    ))
                .LinkSubscribable()
                .NonLazy();

            container.Bind<IToasterTextsUIInteractor, ToasterTextsUIInteractor>()
                .FromFunction(c => new ToasterTextsUIInteractor(
                    c.Resolve<ToasterTextsUIViewModel>()
                    ))
                .LinkSubscribable()
                .NonLazy();
        }

        private void InstallUseCases(IDIContainerBuilder container)
        {

        }
    }
}
