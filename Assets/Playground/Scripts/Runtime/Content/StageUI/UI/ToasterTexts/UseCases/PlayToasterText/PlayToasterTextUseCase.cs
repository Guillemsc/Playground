using Juce.Core.Disposables;
using Playground.Content.StageUI.UI.ToasterTexts.Entries;
using Playground.Content.StageUI.UI.ToasterTexts.Factories;
using Playground.Content.StageUI.UI.ToasterTexts.UseCases.DespawnToasterText;
using Playground.Content.StageUI.UI.ToasterTexts.UseCases.TrySpawnToasterText;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.StageUI.UI.ToasterTexts.UseCases.PlayToasterText
{
    public class PlayToasterTextUseCase : IPlayToasterTextUseCase
    {
        private readonly ITrySpawnToasterTextUseCase trySpawnToasterTextUseCase;
        private readonly IDespawnToasterTextUseCase despawnToasterTextUseCase;

        public PlayToasterTextUseCase(
            ITrySpawnToasterTextUseCase trySpawnToasterTextUseCase,
            IDespawnToasterTextUseCase despawnToasterTextUseCase
            )
        {
            this.trySpawnToasterTextUseCase = trySpawnToasterTextUseCase;
            this.despawnToasterTextUseCase = despawnToasterTextUseCase;
        }

        public async Task Execute(string text, CancellationToken cancellationToken)
        {
            bool created = trySpawnToasterTextUseCase.Execute(
                new ToasterTextUIEntryFactoryDefinition(text),
                out IDisposable<ToasterTextUIEntry> creation
                );

            if(!created)
            {
                return;
            }

            await creation.Value.Play(cancellationToken);

            despawnToasterTextUseCase.Execute(creation);
        }
    }
}
