using Juce.CoreUnity.UI;
using System;
using System.Collections.Generic;

namespace Playground.Services.ViewStack
{
    public class ViewQueueRepository
    {
        private readonly List<Type> items = new List<Type>();

        public void Push(Type type)
        {
            items.Add(type);
        }

        public void Pop()
        {
            if(items.Count == 0)
            {
                return;
            }

            items.RemoveAt(items.Count - 1);
        }

        public Type Peek()
        {
            if(items.Count == 0)
            {
                return default;
            }

            return items[items.Count - 1];
        }
    }
}
