using System;
using System.Collections.Generic;

namespace Playground.Content.Stage.Logic.CheckPoints
{
    public class CheckPointRepository
    {
        private readonly List<CheckPoint> items = new List<CheckPoint>();

        public IReadOnlyList<CheckPoint> Items => items;

        public void Add(CheckPoint item)
        {
            items.Add(item);
        }

        public void RemoveAll()
        {
            items.Clear();
        }

        public bool TryGet(int index, out CheckPoint checkPoint)
        {
            foreach(CheckPoint item in items)
            {
                if(item.Index == index)
                {
                    checkPoint = item;
                    return true;
                }
            }

            checkPoint = null;
            return false;
        }
    }
}
