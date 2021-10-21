using Juce.Core.DI.Builder;
using Juce.Core.DI.Extensions;
using Juce.Core.DI.Installers;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using JuceUnity.Core.DI.Extensions;
using Playground.Content.StageUI.UI.ToasterTexts.Entries;
using Playground.Content.StageUI.UI.ToasterTexts.Factories;
using Playground.Content.StageUI.UI.ToasterTexts.UseCases.DespawnToasterText;
using Playground.Content.StageUI.UI.ToasterTexts.UseCases.PlayToasterText;
using Playground.Content.StageUI.UI.ToasterTexts.UseCases.TrySpawnToasterText;
using UnityEngine;

namespace Playground.Content.StageUI.UI.ToasterTexts
{
    [RequireComponent(typeof(ToasterTextsUIView))]
    public class ToasterTextsUIInstaller : MonoBehaviour, IInstaller
    {
        [Header("Setup")]
        [SerializeField] private ToasterTextUIEntry toasterTextUIEntryPrefab = default;

        [Header("References")]
        [SerializeField] private Transform toasterTextsParent = default;

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
                    c.Resolve<ToasterTextsUIViewModel>(),
                    c.Resolve<IPlayToasterTextUseCase>()
                    ))
                .LinkSubscribable()
                .NonLazy();
        }

        private void InstallUseCases(IDIContainerBuilder container)
        {
            container.Bind<IFactory<ToasterTextUIEntryFactoryDefinition, IDisposable<ToasterTextUIEntry>>>()
                .FromFunction(c => new ToasterTextUIEntryFactory(
                    toasterTextUIEntryPrefab,
                    toasterTextsParent
                    ));

            container.Bind<IRepository<IDisposable<ToasterTextUIEntry>>, SimpleRepository<IDisposable<ToasterTextUIEntry>>>()
                .FromNew();

            container.Bind<ITrySpawnToasterTextUseCase>()
                .FromFunction(c => new TrySpawnToasterTextUseCase(
                    c.Resolve<IFactory<ToasterTextUIEntryFactoryDefinition, IDisposable<ToasterTextUIEntry>>>(),
                    c.Resolve<IRepository<IDisposable<ToasterTextUIEntry>>>()
                    ));

            container.Bind<IDespawnToasterTextUseCase>()
                .FromFunction(c => new DespawnToasterTextUseCase(
                    c.Resolve<IRepository<IDisposable<ToasterTextUIEntry>>>()
                    ));

            container.Bind<IPlayToasterTextUseCase>()
                .FromFunction(c => new PlayToasterTextUseCase(
                    c.Resolve<ITrySpawnToasterTextUseCase>(),
                    c.Resolve<IDespawnToasterTextUseCase>()
                    ));
        }
    }
}
