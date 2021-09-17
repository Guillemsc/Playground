using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class ShipEntityView : MonoBehaviour
    {
        public int InstanceId { get; private set; }
        public string TypeId { get; private set; }

        public void Init(
            int instanceId,
            string typeId
            )
        {
            InstanceId = instanceId;
            TypeId = typeId;
        }
    }
}
