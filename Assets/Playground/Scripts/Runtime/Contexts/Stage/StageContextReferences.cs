using UnityEngine;

namespace Playground.Contexts.Stage
{
    [System.Serializable]
    public class StageContextReferences 
    {
        [SerializeField] private Transform shipParent = default;

        public Transform ShipParent => shipParent;
    }
}
