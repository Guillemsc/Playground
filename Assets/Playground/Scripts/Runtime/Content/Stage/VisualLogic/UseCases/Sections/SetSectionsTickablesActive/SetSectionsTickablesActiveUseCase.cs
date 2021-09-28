using Playground.Content.Stage.VisualLogic.Tickables;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetSectionsTickablesActive
{
    public class SetSectionsTickablesActiveUseCase : ISetSectionsTickablesActiveUseCase
    {
        private readonly GenerateSectionsTickable generateSectionsTickable;
        private readonly CleanSectionsTickable cleanSectionsTickable;

        public SetSectionsTickablesActiveUseCase(
            GenerateSectionsTickable generateSectionsTickable,
            CleanSectionsTickable cleanSectionsTickable
            )
        {
            this.generateSectionsTickable = generateSectionsTickable;
            this.cleanSectionsTickable = cleanSectionsTickable;
        }

        public void Execute(bool active)
        {
            generateSectionsTickable.Active = active;
            cleanSectionsTickable.Active = active;
        }
    }
}
