using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.DespawnSection
{
    public class DespawnSectionUseCase : IDespawnSectionUseCase
    {
        private readonly IRepository<IDisposable<SectionEntityView>> sectionEntityViewRepository;

        public DespawnSectionUseCase(IRepository<IDisposable<SectionEntityView>> sectionEntityViewRepository)
        {
            this.sectionEntityViewRepository = sectionEntityViewRepository;
        }

        public void Execute(IDisposable<SectionEntityView> sectionEntityView)
        {
            bool contains = sectionEntityViewRepository.Contains(sectionEntityView);

            if(!contains)
            {
                UnityEngine.Debug.LogError("Tried to despawn section but it was not present on the repository");
                return;
            }

            sectionEntityViewRepository.Remove(sectionEntityView);

            sectionEntityView.Dispose();
        }
    }
}
