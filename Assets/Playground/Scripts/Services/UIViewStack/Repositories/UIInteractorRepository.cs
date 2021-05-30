using Juce.CoreUnity.UI;
using System;
using System.Collections.Generic;

namespace Playground.Services.ViewStack
{
    public class UIInteractorRepository
    {
        private readonly Dictionary<Type, UIInteractor> items = new Dictionary<Type, UIInteractor>();

        public void Add(UIInteractor uiInteractor)
        {
            Type type = uiInteractor.GetType();

            items.Add(type, uiInteractor);
        }

        public void Remove(UIInteractor uiInteractor)
        {
            Type type = uiInteractor.GetType();

            items.Remove(type);
        }

        public bool TryGet(Type type, out UIInteractor uiInteractor)
        {
            return items.TryGetValue(type, out uiInteractor);
        }
    }
}
