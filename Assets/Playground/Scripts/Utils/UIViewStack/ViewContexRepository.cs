using Playground.Utils.UI;
using System.Collections.Generic;

namespace Playground.Utils.UIViewStack
{
    public class ViewContexRepository
    {
        private readonly List<ViewContex> items = new List<ViewContex>();

        public IReadOnlyList<ViewContex> Items => items;

        public void Add(ViewContex viewContex)
        {
            items.Add(viewContex);
        }

        public void Remove(ViewContex viewContex)
        {
            items.Remove(viewContex);
        }

        public bool Contains(UIView uiView)
        {
            foreach(ViewContex item in items)
            {
                if(item.UIView == uiView)
                {
                    return true;
                }
            }

            return false;
        }

        public bool TryGet(UIView uiView, out ViewContex viewContext)
        {
            foreach(ViewContex item in items)
            {
                if(item.UIView == uiView)
                {
                    viewContext = item;
                    return true;
                }
            }

            viewContext = null;
            return false;
        }

        public ViewContex Peek()
        {
            if(items.Count == 0)
            {
                return null;
            }

            return items[items.Count - 1];
        }
    }
}
