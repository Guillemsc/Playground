using Juce.Timeline.Utils;
using UnityEditor;
using UnityEngine;

namespace Juce.Timeline.Drawers
{
    public static class TimestapsTimelineEditorDrawer 
    {
        public static void Draw(TimelineWindowEditor editor)
        {
            float timestampWidth = 2;
            float timespampHeight = 15;

            int halfTimestampWidth = (int)(timestampWidth * 0.5f);

            Rect backgroundRect = GUILayoutUtility.GetRect(4f, timespampHeight);

            editor.PositionRects.TimestampsRect = backgroundRect;

            float currentTiemstampTime = 0.0f;
            for(int i = 0; i < 999; ++i)
            {
                int timestampPosition = (int)backgroundRect.x + DrawingUtils.TimeToPosition(editor, currentTiemstampTime) - halfTimestampWidth;

                if(timestampPosition >= backgroundRect.xMax)
                {
                    break;
                }

                Rect timestampRect = new Rect(timestampPosition, backgroundRect.y, timestampWidth, timespampHeight);

                timestampRect.xMax = Mathf.Min(timestampRect.xMax, backgroundRect.xMax - 1);

                EditorGUI.DrawRect(timestampRect, Color.grey);

                currentTiemstampTime += editor.SecondsPerTimestamp;
            }
        }
    }
}
