using Juce.Core.Disposables;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.DespawnSection
{
    public interface IDespawnSectionUseCase
    {
        void Execute(IDisposable<SectionEntityView> sectionEntityView);
    }
}
