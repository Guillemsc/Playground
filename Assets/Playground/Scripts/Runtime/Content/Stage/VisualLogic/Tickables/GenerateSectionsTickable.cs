using Juce.Core.Tickable;
using Playground.Content.Stage.VisualLogic.UseCases.GenerateSections;

namespace Playground.Content.Stage.VisualLogic.Tickables
{
    public class GenerateSectionsTickable : ActivableTickable
    {
        private readonly IGenerateSectionsUseCase generateSectionsUseCase;

        public GenerateSectionsTickable(IGenerateSectionsUseCase generateSectionsUseCase) : base(active: false)
        {
            this.generateSectionsUseCase = generateSectionsUseCase;
        }

        protected override void ActivableTick()
        {
            generateSectionsUseCase.Execute();
        }
    }
}
