namespace Juce.Timeline.Utils
{
    public static class TimelineClipUtils
    {
        public static bool CheckNewClipTimeCollidesWithAnotherClip(
            TimelineWindowEditor editor,
            TimelineClip clip,
            float newStartTime,
            out TimelineClip collidingClip
            )
        {
            //TimelineChannel timelineChannel = editor.Timeline.Channels[clip.ChannelIndex];

            //foreach(TimelineClip timelineClip in timelineChannel.Clips)
            //{
            //    if(timelineClip == clip)
            //    {
            //        continue;
            //    }

            //    float newEnd = newStartTime + clip.Duration;

            //    if(newStartTime > timelineClip.StartTime && newStartTime < timelineClip.EndTime)
            //    {
            //        collidingClip = timelineClip;
            //        return true;
            //    }

            //    if (newEnd > timelineClip.StartTime && newEnd < timelineClip.EndTime)
            //    {
            //        collidingClip = timelineClip;
            //        return true;
            //    }
            //}

            collidingClip = default;
            return false;
        }
    }
}
