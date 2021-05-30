using Juce.CoreUnity.UI;
using System;
using System.Collections.Generic;

namespace Playground.Services.ViewStack
{
    public class RegisteredViewsRepository
    {
        private readonly Dictionary<Type, UIView> items = new Dictionary<Type, UIView>();

        public void Add(UIView uiView)
        {
            Type type = uiView.GetType();

            items.Add(type, uiView);
        }

        public void Remove(UIView uiView)
        {
            Type type = uiView.GetType();

            items.Remove(type);
        }

        public bool TryGet(Type type, out UIView uiView)
        {
            return items.TryGetValue(type, out uiView);
        }
    }
}
