using System.Collections.Generic;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class SectionEntityView : MonoBehaviour
    {
        [Header("Positions")]
        [SerializeField] private Transform startPosition = default;
        [SerializeField] private Transform endPosition = default;

        [Header("Spawners")]
        [SerializeField] private List<Transform> spawners = default;

        public string TypeId { get; private set; }

        public Transform StartPosition => startPosition;
        public Transform EndPosition => endPosition;

        public IReadOnlyList<Transform> Spawners => spawners;

        private void OnDrawGizmos()
        {
            if (startPosition != null)
            {
                Gizmos.DrawLine(startPosition.position - Vector3.left * 30, startPosition.position + Vector3.left * 30);
            }

            if (endPosition != null)
            {
                Gizmos.DrawLine(endPosition.position - Vector3.left * 30, endPosition.position + Vector3.left * 30);
            }
        }

        public void Init(
            string typeId
            )
        {
            TypeId = typeId;
        }
    }
}
