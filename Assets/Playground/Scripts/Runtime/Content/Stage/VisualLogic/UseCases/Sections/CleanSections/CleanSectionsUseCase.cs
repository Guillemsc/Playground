using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.UseCases.DespawnSection;

namespace Playground.Content.Stage.VisualLogic.UseCases.CleanSections
{
    public class CleanSectionsUseCase : ICleanSectionsUseCase
    {
        private readonly ISingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository;
        private readonly IRepository<IDisposable<SectionEntityView>> sectionEntityViewRepository;
        private readonly StageSettings stageSettings;
        private readonly IDespawnSectionUseCase despawnSectionUseCase;

        public CleanSectionsUseCase(
            ISingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository,
            IRepository<IDisposable<SectionEntityView>> sectionEntityViewRepository,
            StageSettings stageSettings,
            IDespawnSectionUseCase despawnSectionUseCase
            )
        {
            this.shipEntityViewRepository = shipEntityViewRepository;
            this.sectionEntityViewRepository = sectionEntityViewRepository;
            this.stageSettings = stageSettings;
            this.despawnSectionUseCase = despawnSectionUseCase;
        }

        public void Execute()
        {
            bool shipFound = shipEntityViewRepository.TryGet(out IDisposable<ShipEntityView> shipEntityView);

            if (!shipFound)
            {
                return;
            }

            if(sectionEntityViewRepository.Items.Count == 0)
            {
                return;
            }

            float backwardDistance = shipEntityView.Value.transform.position.y - stageSettings.SectionsBackwardDespawnDistance;

            IDisposable<SectionEntityView> oldestSection = sectionEntityViewRepository.Items[0];

            float nextPosition = oldestSection.Value.EndPosition.transform.position.y;

            if(nextPosition > backwardDistance)
            {
                return;
            }

            despawnSectionUseCase.Execute(oldestSection);
        }
    }
}
