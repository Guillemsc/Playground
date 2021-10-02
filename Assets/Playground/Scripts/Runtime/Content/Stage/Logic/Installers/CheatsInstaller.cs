using Juce.Core.Repositories;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Playground.Content.Stage.Logic.Entities;
using Playground.Cheats;
using Playground.Content.Stage.Logic.Cheats.UseCases.ImmortailitySetActiveCheat;
using Playground.Content.Stage.Logic.Cheats.UseCases.IsImmortalityActiveCheat;

namespace Playground.Content.Stage.Logic.Installers
{
    public class CheatsInstaller : IInstaller
    {
        public void Install(IDIContainerBuilder containerBuilder)
        {
            containerBuilder.Bind<IImmortailitySetActiveCheatUseCase>()
                .FromFunction((c) => new ImmortailitySetActiveCheatUseCase(
                    c.Resolve<ISingleRepository<ShipEntity>>()
                    ));

            containerBuilder.Bind<IIsImmortalityActiveCheatUseCase>()
                .FromFunction((c) => new IsImmortalityActiveCheatUseCase(
                    c.Resolve<ISingleRepository<ShipEntity>>()
                    ));

            containerBuilder.Bind<StageLogicCheats>()
                .FromFunction((c) => new StageLogicCheats(
                    c.Resolve<IImmortailitySetActiveCheatUseCase>(),
                    c.Resolve<IIsImmortalityActiveCheatUseCase>()
                    ));
        }
    }
}
