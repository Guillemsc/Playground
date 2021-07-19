using Juce.Core.Disposables;
using System.Collections.Generic;

namespace Playground.Content.Meta.UI.CarsLibrary
{
    public class CarLibraryUIEntryRepository
    {
        private readonly List<IDisposable<CarLibraryUIEntry>> items = new List<IDisposable<CarLibraryUIEntry>>();

        public IReadOnlyList<IDisposable<CarLibraryUIEntry>> Items => items;

        public void Add(IDisposable<CarLibraryUIEntry> item)
        {
            items.Add(item);
        }

        public void RemoveAll()
        {
            items.Clear();
        }
    }
}
