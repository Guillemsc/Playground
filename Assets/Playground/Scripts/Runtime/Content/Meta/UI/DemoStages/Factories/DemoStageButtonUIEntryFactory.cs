using Juce.Core.Disposables;
using Juce.Core.Events.Generic;
using Juce.Core.Observables;
using Juce.CoreUnity.PointerCallback;
using Playground.Content.Stage.Configuration;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UI.DemoStages
{
    public class DemoStageButtonUIEntryFactory 
    {
        private readonly Transform demoStageButtonUIEntriesParent;
        private readonly DemoStageButtonUIEntry demoStageButtonUIEntryPrefab;
        private readonly ObservableEvent<DemoStageButtonUIEntry, PointerCallbacks> onDemoStageButtonClickedEvent;

        public DemoStageButtonUIEntryFactory(
            Transform demoStageButtonUIEntriesParent,
            DemoStageButtonUIEntry demoStageButtonUIEntryPrefab,
            ObservableEvent<DemoStageButtonUIEntry, PointerCallbacks> onDemoStageButtonClickedEvent
            )
        {
            this.demoStageButtonUIEntriesParent = demoStageButtonUIEntriesParent;
            this.demoStageButtonUIEntryPrefab = demoStageButtonUIEntryPrefab;
            this.onDemoStageButtonClickedEvent = onDemoStageButtonClickedEvent;
        }

        public IDisposable<DemoStageButtonUIEntry> Create(StageConfiguration stageConfiguration)
        {
            DemoStageButtonUIEntry instance = demoStageButtonUIEntryPrefab.InstantiateGameObjectAndGetComponent(
                demoStageButtonUIEntriesParent
                );

            instance.OnClicked += OnDemoStageButtonUIEntryClicked;

            instance.Init(stageConfiguration);

            return new Disposable<DemoStageButtonUIEntry>(instance, Dispose);
        }

        private void Dispose(DemoStageButtonUIEntry instance)
        {
            instance.OnClicked -= OnDemoStageButtonUIEntryClicked;

            instance.DestroyGameObject();
        }

        private void OnDemoStageButtonUIEntryClicked(DemoStageButtonUIEntry demoStageButtonUIEntry, PointerCallbacks pointerCallbacks)
        {
            onDemoStageButtonClickedEvent.Execute(demoStageButtonUIEntry, pointerCallbacks);
        }
    }
}
