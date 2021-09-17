﻿using Juce.CoreUnity.Factories;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class ShipEntityViewFactory : MonoBehaviourFactory<ShipEntityViewDefinition, ShipEntityView>
    {
        public ShipEntityViewFactory(ShipEntityView prefab, Transform parent) : base(prefab, parent)
        {

        }

        protected sealed override void Init(ShipEntityViewDefinition definition, ShipEntityView creation)
        {
            creation.Init(definition.InstanceId, definition.TypeId);
        }
    }
}
