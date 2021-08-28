using UnityEngine;

namespace Juce.Timeline.Utils
{
    public static class MousePickingUtils
    {
        public static bool ChannelMousePicking(
            TimelineWindowEditor editor, 
            Vector2 position, 
            out TimelineChannel channel
            )
        {
            for (int i = 0; i < editor.Timeline.Channels.Count; ++i)
            {
                channel = editor.Timeline.Channels[i];
                Rect channelRect = editor.PositionRects.ChannelsRects[i];

                if (channelRect.Contains(position))
                {
                    return true;
                }
            }

            channel = default;
            return false;
        }

        public static bool ClipMousePicking(
           TimelineWindowEditor editor,
           Vector2 position,
           out TimelineClip clip
           )
        {
            for (int i = 0; i < editor.Timeline.Channels.Count; ++i)
            {
                TimelineChannel channel = editor.Timeline.Channels[i];

                for (int y = 0; y < channel.Clips.Count; ++y)
                {
                    clip = channel.Clips[y];

                    Rect clipRect = editor.PositionRects.ClipsRects[i][y];

                    if (clipRect.Contains(position))
                    {
                        return true;
                    }
                }
            }

            clip = default;
            return false;
        }
    }
}
