using System.Collections.Generic;
using UnityEngine;

namespace Juce.Timeline
{
    [System.Serializable]
    public class TimelineChannel 
    {
        [SerializeField] public List<TimelineClip> Clips = new List<TimelineClip>();
    }
}
