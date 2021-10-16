using UnityEngine;

namespace Playground.Configuration.Stage
{
    public abstract class EffectConfiguration : ScriptableObject
    {
        public abstract void Accept(IEffectConfigurationVisitor visitor);
    }
}
