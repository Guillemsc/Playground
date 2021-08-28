using Juce.Timeline.Drawers;
using UnityEditor;
using UnityEngine;

namespace Juce.Timeline
{
    public class TimelineWindowEditor : EditorWindow
    {
        public bool TimelineMissing { get; private set; }
        public bool TimelineMissingLastUpdate { get; private set; }
        public Timeline LastTimeline { get; private set; }

        public GameObject TimelineGameObject { get; private set; }
        public Timeline Timeline { get; private set; }

        public int DistanceBetweenTimestamps { get; set; } = 30;
        public float SecondsPerTimestamp { get; set; } = 1.0f;
        public float CursorTimePosition { get; set; } = 0.0f;

        public TimelineClip DraggingClip { get; set; }
        public float DraggingClipPositionOffset { get; set; }

        public PositionRects PositionRects { get; } = new PositionRects();

        [MenuItem("Window/JuceTimeline")]
        public static void ShowWindow()
        {
            EditorWindow window = GetWindow(typeof(TimelineWindowEditor));

            window.name = "Juce Timeline";

            window.Show();
        }

        private void OnEnable()
        {
           
        }

        private void OnGUI()
        {
            Repaint();

            TryGetTimelineDirector();

            if (TimelineMissing)
            {
                DrawMissingTimelineDirectorTimelineEditorDrawer.Draw(this);

                return;
            }

            ToolsBarTimelineEditorDrawer.Draw(this);

            EditorGUILayout.Space();

            TimestapsTimelineEditorDrawer.Draw(this);

            ChannelsTimelineEditorDrawer.Draw(this);

            ClipDragTimelineEditorDrawer.Draw(this);

            ClipInspectorTimelineEditorDrawer.Draw(this);

            ChannelsContextMenuTimelineEditorDrawer.Draw(this);

            ChannelsCanvasContextMenuTimelineEditorDrawer.Draw(this);
        }

        private void TryGetTimelineDirector()
        {
            TimelineMissingLastUpdate = TimelineMissing;

            TimelineMissing = true;

            if (Selection.activeGameObject == null && TimelineGameObject == null)
            {
                Timeline = null;
                return;
            }

            if(Selection.activeGameObject != null)
            {
                TimelineGameObject = Selection.activeGameObject;
            }

            Timeline = TimelineGameObject.GetComponent<Timeline>();

            if(Timeline == null)
            {
                TimelineGameObject = null;
                return;
            }

            LastTimeline = Timeline;
            TimelineMissing = false;
        }
    }
}
