using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Playground.Content.StageUI.UI.ToasterTexts.Entries;
using Playground.Content.StageUI.UI.ToasterTexts.Factories;

namespace Playground.Content.StageUI.UI.ToasterTexts.UseCases.TrySpawnToasterText
{
    public class TrySpawnToasterTextUseCase : ITrySpawnToasterTextUseCase
    {
        private readonly IFactory<ToasterTextUIEntryFactoryDefinition, IDisposable<ToasterTextUIEntry>> toasterTextUIEntryFactory;
        private readonly IRepository<IDisposable<ToasterTextUIEntry>> toasterTextUIEntryRepository;

        public TrySpawnToasterTextUseCase(
            IFactory<ToasterTextUIEntryFactoryDefinition, IDisposable<ToasterTextUIEntry>> toasterTextUIEntryFactory,
            IRepository<IDisposable<ToasterTextUIEntry>> toasterTextUIEntryRepository
            )
        {
            this.toasterTextUIEntryFactory = toasterTextUIEntryFactory;
            this.toasterTextUIEntryRepository = toasterTextUIEntryRepository;
        }

        public bool Execute(
            ToasterTextUIEntryFactoryDefinition definition,
            out IDisposable<ToasterTextUIEntry> creation
            )
        {
            bool created = toasterTextUIEntryFactory.TryCreate(
                definition,
                out creation
                );

            if(!created)
            {
                return false;
            }

            toasterTextUIEntryRepository.Add(creation);

            return true;
        }
    }
}
