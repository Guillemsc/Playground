using Juce.CoreUnity.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Juce.Timeline
{
    [ExecuteInEditMode]
    public class Timeline : MonoBehaviour
    {
        [SerializeField] public List<TimelineChannel> Channels = new List<TimelineChannel>();

        private UnityTimer timer = new UnityTimer();

        public TimelineState State { get; private set; }
        public TimeSpan Time { get; private set; }

        public void Play()
        {
            State = TimelineState.Playing;

            timer.Start(Time);
        }

        public void Stop()
        {
            State = TimelineState.Stopped;

            timer.Reset();
        }
    }
}
