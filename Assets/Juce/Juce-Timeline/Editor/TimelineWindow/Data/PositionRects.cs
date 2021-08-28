using System.Collections.Generic;
using UnityEngine;

namespace Juce.Timeline.Drawers
{
    public class PositionRects
    {
        public Rect TimestampsRect { get; set; }
        public List<Rect> ChannelsRects { get; } = new List<Rect>();
        public List<List<Rect>> ClipsRects { get; } = new List<List<Rect>>();
        public Rect ChannelsCanvasRect { get; set; }
    }
}
