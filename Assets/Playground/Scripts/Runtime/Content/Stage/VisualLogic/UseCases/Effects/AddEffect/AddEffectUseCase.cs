using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Effects;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.UseCases.PlayToasterText;
using Playground.Content.Stage.VisualLogic.UseCases.RemoveEffect;
using Playground.Content.StageUI.UI.Effects;
using System.Threading;

namespace Playground.Content.Stage.VisualLogic.UseCases.AddEffect
{
    public class AddEffectUseCase : IAddEffectUseCase
    {
        private readonly IFactory<EffectConfiguration, IDisposable<EffectWithTriggerExpirator>> effectsFactory;
        private readonly IRepository<IDisposable<EffectWithTriggerExpirator>> effectsRepository;
        private readonly IEffectsUIInteractor effectsUIInteractor;
        private readonly IRemoveEffectUseCase removeEffectUseCase;
        private readonly IPlayToasterTextUseCase playToasterTextUseCase;

        public AddEffectUseCase(
            IFactory<EffectConfiguration, IDisposable<EffectWithTriggerExpirator>> effectsFactory,
            IRepository<IDisposable<EffectWithTriggerExpirator>> effectsRepository,
            IEffectsUIInteractor effectsUIInteractor,
            IRemoveEffectUseCase removeEffectUseCase,
            IPlayToasterTextUseCase playToasterTextUseCase
            )
        {
            this.effectsFactory = effectsFactory;
            this.effectsRepository = effectsRepository;
            this.effectsUIInteractor = effectsUIInteractor;
            this.removeEffectUseCase = removeEffectUseCase;
            this.playToasterTextUseCase = playToasterTextUseCase;
        }

        public void Execute(EffectEntityView effectEntityView)
        {
            EffectConfiguration effectConfiguration = effectEntityView.EffectConfiguration;

            bool created = effectsFactory.TryCreate(effectConfiguration, out IDisposable<EffectWithTriggerExpirator> creation);

            if(!created)
            {
                UnityEngine.Debug.LogError($"{nameof(EffectWithTriggerExpirator)} could not be created," +
                    $" at {nameof(AddEffectUseCase)}");
                return;
            }

            effectsRepository.Add(creation);

            effectsUIInteractor.AddEffect(effectEntityView, creation.Value);

            playToasterTextUseCase.Execute("Effect!");

            creation.Value.OnExpired += () => removeEffectUseCase.Execute(creation);
        }
    }
}
