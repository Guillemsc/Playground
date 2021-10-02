using Playground.Content.Stage.Logic.Cheats.UseCases.ImmortailitySetActiveCheat;
using Playground.Content.Stage.Logic.Cheats.UseCases.IsImmortalityActiveCheat;
using System.ComponentModel;

namespace Playground.Cheats
{
    public class StageLogicCheats
    {
        private readonly IImmortailitySetActiveCheatUseCase immortailitySetActiveCheatUseCase;
        private readonly IIsImmortalityActiveCheatUseCase isImmortalityActiveCheatUseCase;

        public StageLogicCheats(
            IImmortailitySetActiveCheatUseCase immortailitySetActiveCheatUseCase,
            IIsImmortalityActiveCheatUseCase isImmortalityActiveCheatUseCase
            )
        {
            this.immortailitySetActiveCheatUseCase = immortailitySetActiveCheatUseCase;
            this.isImmortalityActiveCheatUseCase = isImmortalityActiveCheatUseCase;
        }

        [Category("Immortality")]
        public bool Immortality
        {
            get => isImmortalityActiveCheatUseCase.Execute();
            set => immortailitySetActiveCheatUseCase.Execute(value);
        }
    }
}
