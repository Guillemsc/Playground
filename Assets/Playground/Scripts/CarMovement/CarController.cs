using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<WheelCollider> motorWheels = default;
    [SerializeField] private List<WheelCollider> leftSteeringWheels = default;
    [SerializeField] private List<WheelCollider> rightSteeringWheels = default;

    [Header("Configuration")]
    [SerializeField] CarControllerConfiguration carControllerConfiguration = default;

    private int currentTorqueDirection = 0;
    private int currentSteeringDirection = 0;
    private float currentSteer = 0;

    private void Update()
    {
        //currentTorqueDirection = 0;
        //currentSteeringDirection = 0;

        if (Input.GetKey("w"))
        {
            Accelerate();
        }

        if (Input.GetKey("s"))
        {
            Break();
        }

        if (Input.GetKey("a"))
        {
            SteerLeft();
        }

        if (Input.GetKey("d"))
        {
            SteerRight();
        }

        SetWheelsTorque();
        SetWheelsSteering();
    }

    private void LateUpdate()
    {
        ClearFrame();
    }

    public void Accelerate()
    {
        currentTorqueDirection = 1;
    }

    public void Break()
    {
        currentTorqueDirection = -1;
    }

    public void SteerLeft()
    {
        currentSteeringDirection = -1;
    }

    public void SteerRight()
    {
        currentSteeringDirection = 1;
    }

    public void ClearFrame()
    {
        currentTorqueDirection = 0;
        currentSteeringDirection = 0;
    }

    private void Steer(float force)
    {
        currentSteer += force;

        if(currentSteer > carControllerConfiguration.MaxSteeringAngle)
        {
            currentSteer = carControllerConfiguration.MaxSteeringAngle;
        }

        if(currentSteer < -carControllerConfiguration.MaxSteeringAngle)
        {
            currentSteer = -carControllerConfiguration.MaxSteeringAngle;
        }
    }

    private void SetWheelsTorque()
    {
        if (currentSteeringDirection != 0)
        {
            float steeringDt = carControllerConfiguration.Steering * Time.deltaTime;

            Steer(currentSteeringDirection * steeringDt);
        }
        else
        {
            float unsteeringDt = carControllerConfiguration.Unsteering * Time.deltaTime;

            if (currentSteer > 0)
            {
                if (currentSteer - unsteeringDt < 0)
                {
                    currentSteer = 0;
                }
                else
                {
                    currentSteer -= unsteeringDt;
                }
            }
            else if (currentSteer < 0)
            {
                if (currentSteer + unsteeringDt > 0)
                {
                    currentSteer = 0;
                }
                else
                {
                    currentSteer += unsteeringDt;
                }
            }
        }

        foreach (WheelCollider wheelCollider in motorWheels)
        {
            wheelCollider.motorTorque = currentTorqueDirection * carControllerConfiguration.Torque;
        }
    }

    private void SetWheelsSteering()
    {
        foreach(WheelCollider wheelCollider in leftSteeringWheels)
        {
            wheelCollider.steerAngle = currentSteer;
        }

        foreach (WheelCollider wheelCollider in rightSteeringWheels)
        {
            wheelCollider.steerAngle = currentSteer;
        }
    }
}
