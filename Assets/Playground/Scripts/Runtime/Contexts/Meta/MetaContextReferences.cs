using Playground.Content.Meta.UI.StageEnd;
using UnityEngine;

namespace Playground.Contexts.Meta
{
    [System.Serializable]
    public class MetaContextReferences
    {
        [Header("References")]
        [SerializeField] private StageEndUIInstaller stageEndUIInstaller = default;

        public StageEndUIInstaller StageEndUIInstaller => stageEndUIInstaller;
    }
}
