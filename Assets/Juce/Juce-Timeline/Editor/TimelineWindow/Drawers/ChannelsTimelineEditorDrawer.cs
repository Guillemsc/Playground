using Juce.Timeline.Utils;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Juce.Timeline.Drawers
{
    public static class ChannelsTimelineEditorDrawer
    {
        public static void Draw(TimelineWindowEditor editor)
        {
            int timelineChannelHeight = 32;
            int timelineClipHeight = 26;
            int clipYOffset = 3;

            editor.PositionRects.ChannelsRects.Clear();
            editor.PositionRects.ClipsRects.Clear();

            foreach (TimelineChannel channel in editor.Timeline.Channels)
            {
                EditorGUILayout.Space();

                Rect backgroundRect = GUILayoutUtility.GetRect(4f, timelineChannelHeight);

                editor.PositionRects.ChannelsRects.Add(backgroundRect);

                List<Rect> clipsRect = new List<Rect>();
                editor.PositionRects.ClipsRects.Add(clipsRect);

                EditorGUI.DrawRect(backgroundRect, new Color(0.1f, 0.1f, 0.1f));

                foreach (TimelineClip clip in channel.Clips)
                {
                    float clipStartPosition = DrawingUtils.TimeToPosition(editor, clip.StartTime);
                    float clipEndPosition = DrawingUtils.TimeToPosition(editor, clip.EndTime);

                    Rect clipRect = new Rect(
                        backgroundRect.x + clipStartPosition, 
                        backgroundRect.y + clipYOffset, 
                        clipEndPosition - clipStartPosition,
                        timelineClipHeight
                        );

                    clipRect.xMax = Mathf.Min(clipRect.xMax, backgroundRect.xMax - 1);

                    clipsRect.Add(clipRect);

                    EditorGUI.DrawRect(clipRect, Color.blue);
                }
            }
        }
    }
}
