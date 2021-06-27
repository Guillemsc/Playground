using UnityEngine;

namespace Playground.Configuration.Stage
{
    [System.Serializable]
    public class StageStarsCarConfiguration
    {
        [SerializeField] private string carTypeId = default;
        [SerializeField] [Min(0)] private float star1Timing = 5;
        [SerializeField] [Min(0)] private float star2Timing = 10;
        [SerializeField] [Min(0)] private float star3Timing = 15;

        public string CarTypeId => carTypeId;
        public float Star1Timing => star1Timing;
        public float Star2Timing => star2Timing;
        public float Star3Timing => star3Timing;

        public StageStarsCarConfiguration(
            string carTypeId,
            float star1Timing,
            float star2Timing,
            float star3Timing
            )
        {
            this.carTypeId = carTypeId;
            this.star1Timing = star1Timing;
            this.star2Timing = star2Timing;
            this.star3Timing = star3Timing;
        }
    }
}
