using Playground.Content.Meta.UI.StageEnd;
using UnityEngine;

namespace Playground.Contexts.Meta
{
    public class MetaContextInstance : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private StageEndUIInstaller stageEndUIInstaller = default;

        public StageEndUIInstaller StageEndUIInstaller => stageEndUIInstaller;
    }
}
