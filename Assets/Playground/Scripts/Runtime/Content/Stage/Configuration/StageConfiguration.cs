using UnityEngine;

namespace Playground.Content.Stage.Configuration
{
    [CreateAssetMenu(fileName = "StageConfiguration", menuName = "Playground/Configuration/StageConfiguration", order = 1)]
    public class StageConfiguration : ScriptableObject
    {
        [SerializeField] private SceneReference stageSceneReference = default;

        public SceneReference StageSceneReference => stageSceneReference;
    }
}
