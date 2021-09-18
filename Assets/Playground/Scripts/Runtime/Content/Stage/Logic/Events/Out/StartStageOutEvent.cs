using Playground.Content.Stage.Logic.Snapshots;

namespace Playground.Content.Stage.Logic.Events
{
    public class StartStageOutEvent
    {
        public ShipEntitySnapshot ShipEntitySnapshot { get; }

        public StartStageOutEvent(
            ShipEntitySnapshot shipEntitySnapshot
            )
        {
            ShipEntitySnapshot = shipEntitySnapshot;
        }
    }
}
