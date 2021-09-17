﻿using Juce.Utils.Singletons;
using System;
using System.Collections.Generic;

namespace Juce.CoreUnity.Service
{
    public class ServicesProvider : AutoStartMonoSingleton<ServicesProvider>
    {
        private readonly List<IService> allServices = new List<IService>();
        private readonly List<IUpdatableService> updatableServices = new List<IUpdatableService>();

        private void Update()
        {
            UpdateUpdatableServices();
        }

        private void OnApplicationQuit()
        {
            CleanUpAllServices();
        }

        public static void Register<T>(T service) where T : IService
        {
            if (InstanceWasDestroyed)
            {
                return;
            }

            Instance.RegisterService(service);
        }

        public static void Unregister(IService service)
        {
            if(InstanceWasDestroyed)
            {
                return;
            }

            Instance.UnregisterService(service);
        }

        public static T GetService<T>() where T : IService
        {
            if (InstanceWasDestroyed)
            {
                return default;
            }

            Instance.TryGet(out T service);

            return service;
        }

        public static bool TryGetService<T>(out T service) where T : IService
        {
            if(InstanceWasDestroyed)
            {
                service = default;
                return false;
            }

            return Instance.TryGet(out service);
        }

        public void RegisterService<T>(T service) where T : IService
        {
            if (service == null)
            {
                UnityEngine.Debug.LogError($"Tried to register null service at {nameof(ServicesProvider)}");
            }

            bool alreadyExists = TryGet<T>(out _);

            if (alreadyExists)
            {
                UnityEngine.Debug.LogError($"Service {typeof(T).Name} has been already added at {nameof(ServicesProvider)}");
            }

            allServices.Add(service);

            IUpdatableService updatableService = service as IUpdatableService;

            if (updatableService != null)
            {
                updatableServices.Add(updatableService);
            }

            service.Init();
        }

        public void UnregisterService(IService service)
        {
            if (service == null)
            {
                UnityEngine.Debug.LogError($"Tried to unregister null service at {nameof(ServicesProvider)}");
            }

            bool found = allServices.Remove(service);

            if (!found)
            {
                UnityEngine.Debug.LogError($"Tried to unregister service {service.GetType().Name} but it could" +
                    $"not be found at {nameof(ServicesProvider)}");
            }

            IUpdatableService updatableService = service as IUpdatableService;

            if (updatableService != null)
            {
                updatableServices.Remove(updatableService);
            }

            service.CleanUp();
        }

        private bool TryGet<T>(out T outService) where T : IService
        {
            Type serviceType = typeof(T);

            for (int i = 0; i < allServices.Count; ++i)
            {
                if (allServices[i].GetType() == serviceType)
                {
                    outService = (T)allServices[i];
                    return true;
                }
            }

            outService = default;
            return false;
        }

        private void UpdateUpdatableServices()
        {
            for (int i = 0; i < updatableServices.Count; ++i)
            {
                updatableServices[i].Update();
            }
        }

        private void CleanUpAllServices()
        {
            for (int i = 0; i < allServices.Count; ++i)
            {
                allServices[i].CleanUp();
            }

            updatableServices.Clear();
            allServices.Clear();
        }
    }
}