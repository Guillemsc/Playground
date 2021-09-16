using Playground.Content.Stage.Logic.Snapshots;

namespace Playground.Content.Stage.Logic.Events
{
    public class SetupStageOutEvent
    {
        public ShipEntitySnapshot ShipEntitySnapshot { get; }

        public SetupStageOutEvent(
            ShipEntitySnapshot shipEntitySnapshot
            )
        {
            ShipEntitySnapshot = shipEntitySnapshot;
        }
    }
}
