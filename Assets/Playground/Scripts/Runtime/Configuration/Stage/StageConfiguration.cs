using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = "StageConfiguration", menuName = "Playground/Configuration/StageConfiguration", order = 1)]
    public class StageConfiguration : ScriptableObject
    {
        [SerializeField] private SceneReference stageSceneReference = default;

        public SceneReference StageSceneReference => stageSceneReference;
    }
}
