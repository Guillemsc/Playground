using Juce.Timeline.Utils;
using UnityEngine;

namespace Juce.Timeline.Drawers
{
    public static class ClipDragTimelineEditorDrawer
    {
        public static void Draw(TimelineWindowEditor editor)
        {
            if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
            {
                bool found = MousePickingUtils.ClipMousePicking(
                    editor,
                    Event.current.mousePosition,
                    out TimelineClip foundClip
                    );

                if(found)
                {
                    editor.DraggingClip = foundClip;

                    float startPosition = DrawingUtils.TimeToPosition(editor, editor.DraggingClip.StartTime);

                    editor.DraggingClipPositionOffset = Event.current.mousePosition.x - startPosition;
                }
            }

            if (Event.current.type == EventType.MouseUp && Event.current.button == 0)
            {
                editor.DraggingClip = null;
            }

            if(editor.DraggingClip == null)
            {
                return;
            }

            float duration = editor.DraggingClip.Duration;

            float newPosition = Event.current.mousePosition.x - editor.DraggingClipPositionOffset;

            float newStartTime = DrawingUtils.PositionToTime(editor, (int)newPosition);

            editor.DraggingClip.StartTime = Mathf.Max(0, newStartTime);
            editor.DraggingClip.Duration = duration;

            UnityEngine.Debug.Log($"{editor.DraggingClip.StartTime}, {editor.DraggingClip.EndTime}, {editor.DraggingClip.Duration}");
        }
    }
}
