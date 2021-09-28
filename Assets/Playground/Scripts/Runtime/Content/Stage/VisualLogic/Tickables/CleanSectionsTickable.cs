using Juce.Core.Tickable;
using Playground.Content.Stage.VisualLogic.UseCases.CleanSections;

namespace Playground.Content.Stage.VisualLogic.Tickables
{
    public class CleanSectionsTickable : ITickable
    {
        private readonly ICleanSectionsUseCase cleanSectionsUseCase;

        public bool Active { get; set; } = false;

        public CleanSectionsTickable(ICleanSectionsUseCase cleanSectionsUseCase)
        {
            this.cleanSectionsUseCase = cleanSectionsUseCase;
        }

        public void Tick()
        {
            if (!Active)
            {
                return;
            }

            cleanSectionsUseCase.Execute();
        }
    }
}
