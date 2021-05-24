using Juce.CoreUnity.PointerCallback;
using Playground.Content.Stage.VisualLogic.View.Car;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UI
{
    public class CarControlsUIView : MonoBehaviour
    {
        [SerializeField] private PointerCallbacks acceleratorPointerCallbacks;
        [SerializeField] private PointerCallbacks breakPointerCallbacks;
        [SerializeField] private PointerCallbacks leftPointerCallbacks;
        [SerializeField] private PointerCallbacks rightPointerCallbacks;

        private CarViewController carController = default;

        void Start()
        {
            carController = FindObjectOfType<CarViewController>();
        }

        // Update is called once per frame
        void Update()
        {
            //carController.BeginUpdate();

            //if (acceleratorPointerCallbacks.PressState == PointerCallbackPressState.Down)
            //{
            //    carController.Accelerate();
            //}

            //if (breakPointerCallbacks.PressState == PointerCallbackPressState.Down)
            //{
            //    carController.Break();
            //}

            //if (leftPointerCallbacks.PressState == PointerCallbackPressState.Down)
            //{
            //    carController.SteerLeft();
            //}

            //if (rightPointerCallbacks.PressState == PointerCallbackPressState.Down)
            //{
            //    carController.SteerRight();
            //}
        }
    }
}
