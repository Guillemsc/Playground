namespace Juce.Timeline.Utils
{
    public static class DrawingUtils
    {
        public static int TimeToPosition(TimelineWindowEditor editor, float time)
        {
            return (int)((time / editor.SecondsPerTimestamp) * (float)editor.DistanceBetweenTimestamps);
        }

        public static float PositionToTime(TimelineWindowEditor editor, int position)
        {
            return ((float)position / (float)editor.DistanceBetweenTimestamps) * editor.SecondsPerTimestamp;
        }
    }
}
