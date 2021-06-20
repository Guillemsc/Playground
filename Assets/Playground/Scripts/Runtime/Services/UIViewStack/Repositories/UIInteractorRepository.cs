using Juce.CoreUnity.UI;
using System;
using System.Collections.Generic;

namespace Playground.Services.ViewStack
{
    public class UIInteractorRepository
    {
        private readonly Dictionary<Type, UIInteractor> items = new Dictionary<Type, UIInteractor>();

        public void Add(UIView view, UIInteractor uiInteractor)
        {
            Type type = view.GetType();

            items.Add(type, uiInteractor);
        }

        public void Remove(UIView view)
        {
            Type type = view.GetType();

            items.Remove(type);
        }

        public bool TryGet(Type type, out UIInteractor uiInteractor)
        {
            return items.TryGetValue(type, out uiInteractor);
        }

        public bool TryGet<T>(out UIInteractor uiInteractor) where T : UIInteractor
        {
            Type type = typeof(T);

            foreach(KeyValuePair<Type, UIInteractor> item in items)
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
