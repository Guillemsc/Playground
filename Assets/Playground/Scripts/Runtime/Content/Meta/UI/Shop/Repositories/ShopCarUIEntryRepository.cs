using Juce.Core.Disposables;
using System.Collections.Generic;

namespace Playground.Content.Meta.UI.Shop
{
    public class ShopCarUIEntryRepository
    {
        private readonly List<IDisposable<ShopCarUIEntry>> items = new List<IDisposable<ShopCarUIEntry>>();

        public IReadOnlyList<IDisposable<ShopCarUIEntry>> Items => items;

        public void Add(IDisposable<ShopCarUIEntry> item)
        {
            items.Add(item);
        }

        public void RemoveAll()
        {
            items.Clear();
        }
    }
}
