using UnityEngine;

namespace Playground.Content.Stage.Configuration
{
    [CreateAssetMenu(fileName = "StageConfiguration", menuName = "Playground/Configuration/StageConfiguration", order = 1)]
    public class StageConfiguration : ScriptableObject
    {
        [SerializeField] private SceneReference stageScene = default;

        public SceneReference StageScene => stageScene;
    }
}
