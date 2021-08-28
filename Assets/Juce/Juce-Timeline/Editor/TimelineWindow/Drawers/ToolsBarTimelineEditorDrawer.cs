using Juce.Timeline.Utils;
using UnityEditor;
using UnityEngine;

namespace Juce.Timeline.Drawers
{
    public static class ToolsBarTimelineEditorDrawer
    {
        public static void Draw(TimelineWindowEditor editor)
        {
            editor.DistanceBetweenTimestamps = EditorGUILayout.IntField("Zoom", editor.DistanceBetweenTimestamps);

            if (editor.TimelineMissing || editor.Timeline.State == TimelineState.Stopped)
            {
                editor.CursorTimePosition = EditorGUILayout.FloatField("Cursor", editor.CursorTimePosition);
            }
            else
            {
                EditorGUILayout.LabelField($"Cursor {editor.CursorTimePosition}");
            }

            editor.CursorTimePosition = Mathf.Max(0, editor.CursorTimePosition);

            EditorGUI.BeginDisabledGroup(editor.TimelineMissing);
            {
                EditorGUILayout.BeginHorizontal();
                {
                    if (GUILayout.Button("Play"))
                    {
                        editor.Timeline.Play();
                    }

                    if (GUILayout.Button("Stop"))
                    {
                        editor.Timeline.Stop();
                    }
                }
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();
            }
            EditorGUI.EndDisabledGroup();
        }
    }
}
