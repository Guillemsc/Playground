using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.UseCases.TrySpawnRandomSectionEffect;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UseCases.TrySpawnRandomSection
{
    public class TrySpawnRandomSectionUseCase : ITrySpawnRandomSectionUseCase
    {
        private readonly IFactory<SectionEntityViewDefinition, IDisposable<SectionEntityView>> sectionEntityViewFactory;
        private readonly IRepository<IDisposable<SectionEntityView>> sectionEntityViewRepository;
        private readonly Transform sectionsStartPosition;
        private readonly SectionsVisualLogicSetup visualLogicSectionsSetup;
        private readonly ITrySpawnRandomSectionEffectUseCase trySpawnSectionEffectUseCase;

        public TrySpawnRandomSectionUseCase(
            IFactory<SectionEntityViewDefinition, IDisposable<SectionEntityView>> sectionEntityViewFactory,
            IRepository<IDisposable<SectionEntityView>> sectionEntityViewRepository,
            Transform sectionsStartPosition,
            SectionsVisualLogicSetup visualLogicSectionsSetup,
             ITrySpawnRandomSectionEffectUseCase trySpawnSectionEffectUseCase
            )
        {
            this.sectionEntityViewFactory = sectionEntityViewFactory;
            this.sectionEntityViewRepository = sectionEntityViewRepository;
            this.sectionsStartPosition = sectionsStartPosition;
            this.visualLogicSectionsSetup = visualLogicSectionsSetup;
            this.trySpawnSectionEffectUseCase = trySpawnSectionEffectUseCase;
        }

        public void Execute(float position)
        {
            if (visualLogicSectionsSetup.Sections.Count == 0)
            {
                UnityEngine.Debug.LogError("No avaliable sections to spawn");
                return;
            }

            int randomIndex = Random.Range(0, visualLogicSectionsSetup.Sections.Count);

            SectionEntityView prefab = visualLogicSectionsSetup.Sections[randomIndex];

            bool created = sectionEntityViewFactory.TryCreate(
                new SectionEntityViewDefinition(
                    string.Empty,
                    prefab
                    ),
                out IDisposable<SectionEntityView> sectionEntityView
                );

            if (!created)
            {
                UnityEngine.Debug.LogError("Section could not be created");
                return;
            }

            sectionEntityViewRepository.Add(sectionEntityView);

            float offset = sectionEntityView.Value.transform.position.x - sectionEntityView.Value.StartPosition.position.x;

            Vector2 finalPosition = new Vector2(sectionsStartPosition.position.x, position + offset);

            sectionEntityView.Value.transform.position = finalPosition;

            foreach(Transform spawner in sectionEntityView.Value.Spawners)
            {
                trySpawnSectionEffectUseCase.Execute(spawner);
            }
        }
    }
}
