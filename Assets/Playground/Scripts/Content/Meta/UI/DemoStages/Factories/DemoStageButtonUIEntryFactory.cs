using Juce.Core.Disposables;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UI.DemoStages
{
    public class DemoStageButtonUIEntryFactory 
    {
        private Transform demoStageButtonUIEntriesParent;
        private DemoStageButtonUIEntry demoStageButtonUIEntryPrefab;

        public DemoStageButtonUIEntryFactory(
            Transform demoStageButtonUIEntriesParent,
            DemoStageButtonUIEntry demoStageButtonUIEntryPrefab
            )
        {
            this.demoStageButtonUIEntriesParent = demoStageButtonUIEntriesParent;
            this.demoStageButtonUIEntryPrefab = demoStageButtonUIEntryPrefab;
        }

        public IDisposable<DemoStageButtonUIEntry> Create(string stageName)
        {
            DemoStageButtonUIEntry instance = demoStageButtonUIEntryPrefab.InstantiateGameObjectAndGetComponent(
                demoStageButtonUIEntriesParent
                );

            instance.Init(stageName);

            return new Disposable<DemoStageButtonUIEntry>(instance, Dispose);
        }

        private void Dispose(DemoStageButtonUIEntry instance)
        {
            instance.DestroyGameObject();
        }
    }
}
