using Juce.Core.Tickable;
using Playground.Content.Stage.VisualLogic.UseCases.CleanSections;

namespace Playground.Content.Stage.VisualLogic.Tickables
{
    public class CleanSectionsTickable : ActivableTickable
    {
        private readonly ICleanSectionsUseCase cleanSectionsUseCase;

        public CleanSectionsTickable(ICleanSectionsUseCase cleanSectionsUseCase) : base (active: false)
        {
            this.cleanSectionsUseCase = cleanSectionsUseCase;
        }

        protected override void ActivableTick()
        {
            cleanSectionsUseCase.Execute();
        }
    }
}
