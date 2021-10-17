using Playground.Content.Stage.Setup;
using Playground.Content.Stage.VisualLogic.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = nameof(EffectsConfiguration), menuName = "Playground/Configuration/Stage/" + nameof(EffectsConfiguration), order = 1)]
    public class EffectsConfiguration : ScriptableObject
    {
        [SerializeField] private List<EffectEntityView> effectsEntityViews = default;

        public EffectsSetup ToSetup()
        {
            return new EffectsSetup(
                effectsEntityViews
                );
        }
    }
}
