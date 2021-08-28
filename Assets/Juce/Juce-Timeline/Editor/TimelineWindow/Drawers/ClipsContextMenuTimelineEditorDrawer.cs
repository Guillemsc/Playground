using Juce.Timeline.Utils;
using UnityEditor;
using UnityEngine;

namespace Juce.Timeline.Drawers
{
    public static class ClipsContextMenuTimelineEditorDrawer
    {
        public static void Draw(TimelineWindowEditor editor)
        {
            //if (Event.current.type == EventType.MouseDown && Event.current.button == 1)
            //{
            //    TimelineClip TimelineClip = null;

            //    for (int i = 0; i < editor.TimelineDirector.Timeline.Channels.Count; ++i)
            //    {
            //        TimelineChannel channel = editor.TimelineDirector.Timeline.Channels[i];
            //        Rect channelRect = editor.PositionRects.ChannelsRects[i];

            //        if (channelRect.Contains(Event.current.mousePosition))
            //        {
            //            foundChannel = channel;
            //            break;
            //        }
            //    }

            //    if (foundChannel == null)
            //    {
            //        return;
            //    }

            //    GenericMenu menu = new GenericMenu();

            //    menu.AddItem(new GUIContent("Add Clip"), on: false, () =>
            //    {
            //        TimelineClip newClip = ScriptableObjectUtils.CreateChildScriptableObject<TimelineClip>(
            //            editor.TimelineDirector.Timeline
            //            );

            //        newClip.StartTime = 0.0f;
            //        newClip.EndTime = 1.0f;

            //        foundChannel.Clips.Add(newClip);
            //    });

            //    menu.AddItem(new GUIContent("Remove Channel"), on: false, () =>
            //    {
            //        editor.TimelineDirector.Timeline.Channels.Remove(foundChannel);
            //    });

            //    menu.ShowAsContext();

            //    Event.current.Use();
            //}
        }
    }
}
