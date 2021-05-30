using Juce.Core.Disposables;
using System.Collections.Generic;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UI.DemoStages
{
    public class DemoStageButtonUIEntryRepository
    {
        private readonly List<IDisposable<DemoStageButtonUIEntry>> items = new List<IDisposable<DemoStageButtonUIEntry>>();

        public IReadOnlyList<IDisposable<DemoStageButtonUIEntry>> Items => items;

        public void Add(IDisposable<DemoStageButtonUIEntry> item)
        {
            items.Add(item);
        }

        public void RemoveAll()
        {
            items.Clear();
        }
    }
}
