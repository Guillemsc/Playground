using Playground.Content.Stage.VisualLogic.Tickables;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetTickableSectionGeneratorActive
{
    public class SetTickableSectionGeneratorActiveUseCase : ISetTickableSectionGeneratorActiveUseCase
    {
        private readonly GenerateSectionsTickable generateSectionsTickable;

        public SetTickableSectionGeneratorActiveUseCase(GenerateSectionsTickable generateSectionsTickable)
        {
            this.generateSectionsTickable = generateSectionsTickable;
        }

        public void Execute(bool active)
        {
            generateSectionsTickable.Active = active;
        }
    }
}
