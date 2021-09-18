using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class ShipEntityView : MonoBehaviour
    {
        public int InstanceId { get; private set; }

        public void Init(int instanceId)
        {
            InstanceId = instanceId;
        }
    }
}
