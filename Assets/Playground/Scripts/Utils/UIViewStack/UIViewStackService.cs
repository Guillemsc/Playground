using Juce.CoreUnity.Service;
using Playground.Utils.UI;
using System;
using System.Collections.Generic;

namespace Playground.Utils.UIViewStack
{
    public class UIViewStackService : IService
    {
        private readonly Dictionary<Type, UIView> registeredUIViews = new Dictionary<Type, UIView>();

        private readonly ViewContexRepository viewContexRepository = new ViewContexRepository();

        public void Init()
        {
            
        }

        public void CleanUp()
        {
           
        }

        public void Register(UIView uiView)
        {
            Type type = uiView.GetType();

            registeredUIViews.Add(type, uiView);
        }

        public void Unregister(UIView uiView)
        {
            Type type = uiView.GetType();

            registeredUIViews.Remove(type);
        }

        public ViewStackPushDefinition Push<T>() where T : UIView
        {
            Type type = typeof(T);

            bool found = registeredUIViews.TryGetValue(type, out UIView uiView);

            if(!found)
            {
                UnityEngine.Debug.LogError($"Tried to Push {nameof(UIView)} of type {typeof(T).Name} " +
                    $"but it was not registered, at {nameof(UIViewStackService)}");
            }

            return new ViewStackPushDefinition(
                viewContexRepository,
                uiView
                );
        }

        public ViewStackPopDefinition Pop<T>() where T : UIView
        {
            Type type = typeof(T);

            bool found = registeredUIViews.TryGetValue(type, out UIView uiView);

            if (!found)
            {
                UnityEngine.Debug.LogError($"Tried to Pop {nameof(UIView)} of type {typeof(T).Name} " +
                    $"but it was not registered, at {nameof(UIViewStackService)}");
            }

            return new ViewStackPopDefinition(
                viewContexRepository,
                uiView
                );
        }
    }
}
