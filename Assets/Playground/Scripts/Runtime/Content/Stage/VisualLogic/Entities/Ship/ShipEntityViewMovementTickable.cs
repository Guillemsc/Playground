using Juce.Core.Tickable;
using Playground.Services;
using System;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class ShipEntityViewMovementTickable : ITickable
    {
        private const float MaxSpeed = 3;
        private const float Acceleration = 1.5f;
        private const float RotationSpeed = 50f;

        private const float MaxForwardAngle = 60f;

        private readonly TimeService timeService;

        private Transform movementTransform;

        private float targetForwardAngle = 0.0f;
        private float currentForwardAngle = 0.0f;
        private float currentForwardSpeed = 0.0f;

        public bool Enabled { get; set; } = false;

        public ShipEntityViewMovementTickable(
            TimeService timeService
            )
        {
            this.timeService = timeService;
        }

        public void Start(Transform movementTransform)
        {
            this.movementTransform = movementTransform;
        }

        public void Tick()
        {
            if(movementTransform == null)
            {
                return;
            }

            if(!Enabled)
            {
                return;
            }

            DebugInput();

            float deltaTime = timeService.ScaledTimeContext.DeltaTime;

            targetForwardAngle = Mathf.Clamp(targetForwardAngle, -MaxForwardAngle, MaxForwardAngle);

            float angleDifference = Mathf.DeltaAngle(currentForwardAngle, targetForwardAngle);

            float angleToChange = 0.0f;

            if(angleDifference > 0)
            {
                angleToChange += RotationSpeed;
            }
            else if(angleDifference < 0)
            {
                angleToChange -= RotationSpeed;
            }

            currentForwardSpeed += Acceleration * deltaTime;
            currentForwardSpeed = Math.Min(currentForwardSpeed, MaxSpeed);

            float deltaTimeAngleToChange = angleToChange * deltaTime;
            float deltaTimeCurrentForwardSpeed = currentForwardSpeed * deltaTime;

            currentForwardAngle += deltaTimeAngleToChange;

            Vector3 newRotation = movementTransform.rotation.eulerAngles;

            Vector3 newPosition = movementTransform.position;

            //newPosition.x += Mathf.Sin(Mathf.Deg2Rad * -currentForwardAngle) * deltaTimeCurrentForwardSpeed;
            //newPosition.y += Mathf.Cos(Mathf.Deg2Rad * -currentForwardAngle) * deltaTimeCurrentForwardSpeed;

            newPosition += movementTransform.up * deltaTimeCurrentForwardSpeed;

            movementTransform.position = newPosition;
            movementTransform.rotation = Quaternion.Euler(newRotation.x, newRotation.y, currentForwardAngle);
        }

        private void DebugInput()
        {
            if(Input.GetKey("a"))
            {
                targetForwardAngle += 100f * Time.deltaTime;
            }

            if (Input.GetKey("d"))
            {
                targetForwardAngle -= 100f * Time.deltaTime;
            }
        }
    }
}
