using Juce.CoreUnity.Contracts;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.View.Car
{
    public class CarView : MonoBehaviour
    {
        [SerializeField] private CarViewController carViewController = default;

        public CarViewController CarViewController => carViewController;

        private void Awake()
        {
            Contract.IsNotNull(carViewController, this);
        }
    }
}
