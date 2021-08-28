using Juce.Timeline.Utils;
using UnityEditor;
using UnityEngine;

namespace Juce.Timeline.Drawers
{
    public static class ChannelsContextMenuTimelineEditorDrawer
    {
        public static void Draw(TimelineWindowEditor editor)
        {
            if(Event.current.type != EventType.MouseDown || Event.current.button != 1)
            {
                return;
            }

            bool found = MousePickingUtils.ChannelMousePicking(
                   editor,
                   Event.current.mousePosition,
                   out TimelineChannel foundChannel
                   );

            if (!found)
            {
                return;
            }

            GenericMenu menu = new GenericMenu();

            menu.AddItem(new GUIContent("Add Clip"), on: false, () =>
            {
                
            });

            menu.AddItem(new GUIContent("Remove Channel"), on: false, () =>
            {
                editor.Timeline.Channels.Remove(foundChannel);
            });

            menu.ShowAsContext();

            Event.current.Use();
        }
    }
}
