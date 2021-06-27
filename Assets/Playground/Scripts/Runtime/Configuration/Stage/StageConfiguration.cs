using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = "StageConfiguration", menuName = "Playground/Configuration/StageConfiguration", order = 1)]
    public class StageConfiguration : ScriptableObject
    {
        [SerializeField] private string stageName = default;
        [SerializeField] private SceneReference stageSceneReference = default;
        [SerializeField] private StageStarsConfiguration stageStarsConfiguration = default;
        [SerializeField] private StageRewardsConfiguration stageRewardsConfiguration = default;

        public string StageName => stageName;
        public SceneReference StageSceneReference => stageSceneReference;
        public StageStarsConfiguration StageStarsConfiguration => stageStarsConfiguration;
        public StageRewardsConfiguration StageRewardsConfiguration => stageRewardsConfiguration;
    }
}
