using UnityEngine;

namespace Playground.Configuration.Stage
{
    public abstract class EffectConfiguration : ScriptableObject
    {
        [Header("General")]
        [SerializeField] private string effectNameTid = default;

        public string EffectNameTid => effectNameTid;

        public abstract void Accept(IEffectConfigurationVisitor visitor);
    }
}
