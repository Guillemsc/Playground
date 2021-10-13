using Playground.Content.Stage.Setup;
using Playground.Content.Stage.VisualLogic.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = nameof(DirectionSelectorConfiguration), menuName = "Playground/Configuration/" + nameof(DirectionSelectorConfiguration), order = 1)]
    public class DirectionSelectorConfiguration : ScriptableObject
    {
        [SerializeField, Min(0)] private float baseSpeedMultiplier = default;

        public DirectionSelectorSetup ToSetup()
        {
            return new DirectionSelectorSetup(
                baseSpeedMultiplier
                );
        }
    }
}
