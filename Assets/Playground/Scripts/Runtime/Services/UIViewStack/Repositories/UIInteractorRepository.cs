using Juce.CoreUnity.UI;
using System;
using System.Collections.Generic;

namespace Playground.Services.ViewStack
{
    public class UIInteractorRepository
    {
        private readonly Dictionary<Type, IUIInteractor> items = new Dictionary<Type, IUIInteractor>();

        public void Add(UIView view, IUIInteractor uiInteractor)
        {
            Type type = view.GetType();

            bool alreadyAdded = items.ContainsKey(type);

            if(alreadyAdded)
            {
                throw new Exception($"{nameof(UIView)} of type {type.Name} was already " +
                    $"added to {nameof(UIInteractorRepository)}");
            }

            items.Add(type, uiInteractor);
        }

        public void Remove(UIView view)
        {
            Type type = view.GetType();

            items.Remove(type);
        }

        public bool TryGet(Type type, out IUIInteractor uiInteractor)
        {
            return items.TryGetValue(type, out uiInteractor);
        }

        public bool TryGet<T>(out IUIInteractor uiInteractor) where T : IUIInteractor
        {
            Type type = typeof(T);

            foreach(KeyValuePair<Type, IUIInteractor> item in items)
            {
                if(item.Value.GetType() == type)
                {
                    uiInteractor = item.Value;
                    return true;
                }
            }

            uiInteractor = null;
            return false;
        }
    }
}
