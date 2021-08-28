using UnityEngine;

namespace Juce.Timeline
{
    [System.Serializable]
    public class TimelineClip 
    {
        [SerializeField] [HideInInspector] private int channelIndex = default;
        [SerializeField] private float startTime = default;
        [SerializeField] private float endTime = default;

        public float StartTime { get => startTime; set => startTime = value; }
        public float EndTime { get => endTime; set => endTime = value; }

        private Vector3 positionToReset = default;


        [SerializeField] private RectTransform testTransform = default;
        [SerializeField] private Vector3 endPosition = default;
        private Vector3 startPosition = default;

        public float Duration 
        { 
            get
            {
                return EndTime - StartTime;
            }

            set
            {
                EndTime = StartTime + value;
            }
        }

        public bool Alive { get; set; }

        public TimelineClip(float startTime, float endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
