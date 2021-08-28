using UnityEditor;
using UnityEngine;

namespace Juce.Timeline.Drawers
{
    public static class ChannelsCanvasContextMenuTimelineEditorDrawer
    {
        public static void Draw(TimelineWindowEditor editor)
        {
            if (Event.current.type == EventType.MouseDown && Event.current.button == 1)
            {
                GenericMenu menu = new GenericMenu();

                menu.AddItem(new GUIContent("Add Channel"), on: false, () =>
                {
                    TimelineChannel channel = new TimelineChannel();

                    editor.Timeline.Channels.Add(channel);
                });

                menu.ShowAsContext();

                Event.current.Use();
            }
        }
    }
}
