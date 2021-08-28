using UnityEditor;
using UnityEngine;

namespace Juce.Timeline.Drawers
{
    public static class DrawMissingTimelineDirectorTimelineEditorDrawer
    {
        public static void Draw(TimelineWindowEditor editor)
        {
            if (Selection.activeGameObject == null)
            {
                GUILayout.Label("Please select a GameObject to start visualizing a timeline");
            }
            else
            {
                GUILayout.Label($"GameObject {Selection.activeGameObject.name} does not contain " +
                    $"a {nameof(Timeline)}");
            }
        }
    }
}
