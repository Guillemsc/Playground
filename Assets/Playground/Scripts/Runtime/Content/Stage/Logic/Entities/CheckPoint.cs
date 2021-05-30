using System;

namespace Playground.Content.Stage.Logic.CheckPoints
{
    public class CheckPoint
    {
        public int Index { get; }
        public bool Passed { get; set; }

        public CheckPoint(
            int index
            )
        {
            Index = index;
        }
    }
}
