using Juce.Core.Factories;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.TrySpawnSections
{
    public class TrySpawnSectionsUseCase : ITrySpawnSectionsUseCase
    {
        private readonly IFactory<SectionEntityViewDefinition, SectionEntityView> sectionEntityViewFactory;

        public TrySpawnSectionsUseCase(
            IFactory<SectionEntityViewDefinition, SectionEntityView> sectionEntityViewFactory
            )
        {
            this.sectionEntityViewFactory = sectionEntityViewFactory;
        }

        public void Execute()
        {

        }
    }
}
