using Juce.Core.Events.Generic;
using Juce.CoreUnity;
using Juce.CoreUnity.Physics;
using System.Collections.Generic;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.View.CheckPoints
{
    public class CheckPointsView : MonoBehaviour
    {
        [SerializeField] private List<CheckPointView> checkPoints = new List<CheckPointView>();

        public IReadOnlyList<CheckPointView> CheckPoints => checkPoints;

        public GenericEvent<CheckPointsView, CheckPointView> OnCheckPointCrossed;

        private void Awake()
        {
            SetupCheckPoints();
        }

        private void OnDestroy()
        {
            CleanUpCheckPoints();
        }

        private void OnDrawGizmos()
        {
            CheckPointView lastCheckPoint = null;

            foreach(CheckPointView checkPoint in checkPoints)
            {
                if(checkPoint == null)
                {
                    continue;
                }

                if (lastCheckPoint == null)
                {
                    lastCheckPoint = checkPoint;
                    continue;
                }

                GizmosUtils.DrawLine(lastCheckPoint.transform.position, checkPoint.transform.position, Color.blue);

                lastCheckPoint = checkPoint;
            }
        }

        public bool TryGet(int index, out CheckPointView foundCheckPointView)
        {
            foreach(CheckPointView checkPointView in checkPoints)
            {
                if(checkPointView.Index == index)
                {
                    foundCheckPointView = checkPointView;
                    return transform;
                }
            }

            foundCheckPointView = null;
            return false;
        }

        private void SetupCheckPoints()
        {
            int index = 0;

            foreach(CheckPointView checkPoint in CheckPoints)
            {
                checkPoint.Init(index);

                checkPoint.OnCrossed += OnCheckPointCross;

                ++index;
            }
        }

        private void CleanUpCheckPoints()
        {
            foreach (CheckPointView checkPoint in CheckPoints)
            {
                checkPoint.OnCrossed -= OnCheckPointCross;
            }
        }

        private void OnCheckPointCross(CheckPointView checkPointView, ColliderData colliderData)
        {
            OnCheckPointCrossed?.Invoke(this, checkPointView);
        }
    }
}
