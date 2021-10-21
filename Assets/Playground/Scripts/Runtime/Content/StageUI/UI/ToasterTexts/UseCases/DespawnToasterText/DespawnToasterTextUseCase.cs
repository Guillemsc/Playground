using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Playground.Content.StageUI.UI.ToasterTexts.Entries;

namespace Playground.Content.StageUI.UI.ToasterTexts.UseCases.DespawnToasterText
{
    public class DespawnToasterTextUseCase : IDespawnToasterTextUseCase
    {
        private readonly IRepository<IDisposable<ToasterTextUIEntry>> toasterTextUIEntryRepository;

        public DespawnToasterTextUseCase(
            IRepository<IDisposable<ToasterTextUIEntry>> toasterTextUIEntryRepository
            )
        {
            this.toasterTextUIEntryRepository = toasterTextUIEntryRepository;
        }

        public void Execute(IDisposable<ToasterTextUIEntry> toasterText)
        {
            toasterTextUIEntryRepository.Remove(toasterText);

            toasterText.Dispose();
        }
    }
}
