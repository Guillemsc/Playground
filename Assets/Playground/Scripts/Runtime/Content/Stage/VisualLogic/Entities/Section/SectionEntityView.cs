﻿using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class SectionEntityView : MonoBehaviour
    {
        [SerializeField] private Transform startPosition = default;
        [SerializeField] private Transform endPosition = default;

        public int InstanceId { get; private set; }
        public string TypeId { get; private set; }

        public Transform StartPosition => startPosition;
        public Transform EndPosition => endPosition;

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
            int instanceId,
            string typeId
            )
        {
            InstanceId = instanceId;
            TypeId = typeId;
        }
    }
}
