using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.UseCases.TrySpawnRandomSection;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UseCases.GenerateSections
{
    public class GenerateSectionsUseCase : IGenerateSectionsUseCase
    {
        private readonly IReadOnlySingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository;
        private readonly IRepository<IDisposable<SectionEntityView>> sectionEntityViewRepository;
        private readonly Transform sectionsStartPosition;
        private readonly SectionsVisualLogicSetup visualLogicSectionsSetup;
        private readonly StageSettings stageSettings;
        private readonly ITrySpawnRandomSectionUseCase trySpawnRandomSectionUseCase;

        public GenerateSectionsUseCase(
            IReadOnlySingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository,
            IRepository<IDisposable<SectionEntityView>> sectionEntityViewRepository,
            Transform sectionsStartPosition,
 
            SectionsVisualLogicSetup visualLogicSectionsSetup,
            StageSettings stageSettings,
            ITrySpawnRandomSectionUseCase trySpawnRandomSectionUseCase
            )
        {
            this.shipEntityViewRepository = shipEntityViewRepository;
            this.sectionEntityViewRepository = sectionEntityViewRepository;
            this.sectionsStartPosition = sectionsStartPosition;
            this.visualLogicSectionsSetup = visualLogicSectionsSetup;
            this.stageSettings = stageSettings;
            this.trySpawnRandomSectionUseCase = trySpawnRandomSectionUseCase;
        }

        public void Execute()
        {
            bool shipFound = shipEntityViewRepository.TryGet(out IDisposable<ShipEntityView> shipEntityView);

            if(!shipFound)
            {
                return;
            }

            while (true)
            {
                if (sectionEntityViewRepository.Items.Count == 0)
                {
                    trySpawnRandomSectionUseCase.Execute(sectionsStartPosition.position.y);

                    continue;
                }

                float forwardDistance = shipEntityView.Value.transform.position.y + stageSettings.SectionsForwardSpawnDistance;

                IDisposable<SectionEntityView> lastSection 
                    = sectionEntityViewRepository.Items[sectionEntityViewRepository.Items.Count - 1];

                float nextPosition = lastSection.Value.EndPosition.transform.position.y + visualLogicSectionsSetup.DistanceBetweenSections;

                if (nextPosition > forwardDistance)
                {
                    break;
                }

                trySpawnRandomSectionUseCase.Execute(nextPosition);
            }
        }
    }
}
