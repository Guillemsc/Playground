using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class PointGoalEntityView : MonoBehaviour
    {
        public int PointValue { get; private set; }

        public void Init(int pointValue)
        {
            PointValue = pointValue;
        }
    }
}
