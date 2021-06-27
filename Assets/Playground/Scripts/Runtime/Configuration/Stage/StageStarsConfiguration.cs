using System.Collections.Generic;
using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = "StageStarsConfiguration", menuName = "Playground/Configuration/StageStarsConfiguration", order = 1)]
    public class StageStarsConfiguration : ScriptableObject
    {
        [SerializeField] public List<StageStarsCarConfiguration> StageStarsCarConfigurations = default;

        public bool TryGet(string carTypeId, out StageStarsCarConfiguration foundStageStarsCarConfiguration)
        {
            foreach(StageStarsCarConfiguration stageStarsCarConfiguration in StageStarsCarConfigurations)
            {
                if(string.Equals(stageStarsCarConfiguration.CarTypeId, carTypeId))
                {
                    foundStageStarsCarConfiguration = stageStarsCarConfiguration;
                    return true;
                }
            }

            foundStageStarsCarConfiguration = default;
            return false;
        }

        public StageStarsCarConfiguration GetDefault(string carTypeId)
        {
            return new StageStarsCarConfiguration(carTypeId, 10, 20, 30);
        }
    }
}
