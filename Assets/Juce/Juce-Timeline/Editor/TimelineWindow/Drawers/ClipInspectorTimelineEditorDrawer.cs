using Juce.Timeline.Utils;
using UnityEditor;
using UnityEngine;

namespace Juce.Timeline.Drawers
{
    public static class ClipInspectorTimelineEditorDrawer
    {
        public static void Draw(TimelineWindowEditor editor)
        {
            if (Event.current.type != EventType.MouseDown || Event.current.button != 0)
            {
                return;
            }

            bool found = MousePickingUtils.ClipMousePicking(
                editor,
                Event.current.mousePosition,
                out TimelineClip foundClip
                );

            if (!found)
            {
                return;
            }

            //Selection.SetActiveObjectWithContext(foundClip, editor.Timeline);

            Event.current.Use();
        }
    }
}
