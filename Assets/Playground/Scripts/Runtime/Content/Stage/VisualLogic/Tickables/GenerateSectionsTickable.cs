using Juce.Core.Tickable;
using Playground.Content.Stage.VisualLogic.UseCases.GenerateSections;

namespace Playground.Content.Stage.VisualLogic.Tickables
{
    public class GenerateSectionsTickable : ITickable
    {
        private readonly IGenerateSectionsUseCase generateSectionsUseCase;

        public bool Active { get; set; } = false;

        public GenerateSectionsTickable(IGenerateSectionsUseCase generateSectionsUseCase)
        {
            this.generateSectionsUseCase = generateSectionsUseCase;
        }

        public void Tick()
        {
            if(!Active)
            {
                return;
            }

            generateSectionsUseCase.Execute();
        }
    }
}
