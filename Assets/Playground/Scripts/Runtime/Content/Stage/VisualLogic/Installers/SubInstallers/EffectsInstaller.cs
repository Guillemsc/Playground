using Juce.Core.DI.Builder;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Juce.CoreUnity.Tickables;
using Juce.CoreUnity.Time;
using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Effects;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Stats;
using Playground.Content.Stage.VisualLogic.Tickables;
using Playground.Content.Stage.VisualLogic.UseCases.AddEffect;
using Playground.Content.Stage.VisualLogic.UseCases.PlayToasterText;
using Playground.Content.Stage.VisualLogic.UseCases.RemoveEffect;
using Playground.Content.StageUI.UI.Effects;

namespace Playground.Content.Stage.VisualLogic.Installers
{
    public static class EffectsInstaller
    {
        public static void InstallEffects(
            this IDIContainerBuilder container,
            TickablesService tickablesService,
            ITimeService timeService
            )
        {
            container.Bind<IFactory<EffectEntityViewDefinition, IDisposable<EffectEntityView>>>()
                .FromFunction(c => new EffectEntityViewFactory());

            container.Bind<TimeTriggersTickable>()
                .FromNew()
                .WhenInit((c, o) => tickablesService.AddTickable(o))
                .WhenDispose((o) => tickablesService.RemoveTickable(o));

            container.Bind<IFactory<EffectConfiguration, IDisposable<EffectWithTriggerExpirator>>>()
               .FromFunction(c => new EffectsFactory(
                   c.Resolve<TimeTriggersTickable>(),
                   c.Resolve<ShipStats>(),
                   timeService.ScaledTimeContext
                   ));

            container.Bind<IRepository<IDisposable<EffectWithTriggerExpirator>>, SimpleRepository<IDisposable<EffectWithTriggerExpirator>>>()
                .FromNew();

            container.Bind<IRemoveEffectUseCase>()
                .FromFunction(c => new RemoveEffectUseCase(
                    c.Resolve<IRepository<IDisposable<EffectWithTriggerExpirator>>>(),
                    c.Resolve<IEffectsUIInteractor>()
                    ));

            container.Bind<IAddEffectUseCase>()
                .FromFunction(c => new AddEffectUseCase(
                    c.Resolve<IFactory<EffectConfiguration, IDisposable<EffectWithTriggerExpirator>>>(),
                    c.Resolve<IRepository<IDisposable<EffectWithTriggerExpirator>>>(),
                    c.Resolve<IEffectsUIInteractor>(),
                    c.Resolve<IRemoveEffectUseCase>(),
                    c.Resolve<IPlayToasterTextUseCase>()
                    )); 
        }
    }
}
