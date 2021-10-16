using Juce.Core.Tickable;
using Playground.Content.Stage.VisualLogic.State;
using Playground.Content.Stage.VisualLogic.Stats;
using Playground.Services;
using System;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class ShipEntityViewMovementTickable : ActivableTickable
    {
        private const float Acceleration = 1.5f;
        private const float RotationSpeed = 70f;

        private const float MaxForwardAngle = 60f;

        private readonly TimeService timeService;
        private readonly ShipStats shipStats;
        private readonly DirectionSelectionState directionSelectionState;

        private Transform movementTransform;

        private float currentForwardAngle = 0.0f;
        private float currentForwardSpeed = 0.0f;

        public ShipEntityViewMovementTickable(
            TimeService timeService,
            ShipStats shipStats,
            DirectionSelectionState directionSelectionState
            ) : base(active: false)
        {
            this.timeService = timeService;
            this.shipStats = shipStats;
            this.directionSelectionState = directionSelectionState;
        }

        public void Start(Transform movementTransform)
        {
            this.movementTransform = movementTransform;
        }

        protected override void ActivableTick()
        {
            if (movementTransform == null)
            {
                return;
            }

            DebugInput();

            float deltaTime = timeService.ScaledTimeContext.DeltaTime;

            float invertedNormalizedValue = 1 - directionSelectionState.LastSelectedDirecitonNormalizedValue;

            float targetForwardAngle = (invertedNormalizedValue * MaxForwardAngle * 2) 
                - MaxForwardAngle;

            float angleDifference = Mathf.DeltaAngle(currentForwardAngle, targetForwardAngle);

            float angleToChange = 0.0f;

            if (angleDifference > 0)
            {
                angleToChange += RotationSpeed;
            }
            else if (angleDifference < 0)
            {
                angleToChange -= RotationSpeed;
            }

            float accelerationDeltaTime = Acceleration * deltaTime;

            if(currentForwardSpeed > shipStats.MovementMaxSpeed.ModifiedValue)
            {
                if(currentForwardSpeed - accelerationDeltaTime < shipStats.MovementMaxSpeed.ModifiedValue)
                {
                    currentForwardSpeed = shipStats.MovementMaxSpeed.ModifiedValue;
                }
                else
                {
                    currentForwardSpeed -= accelerationDeltaTime;
                }
            }
            else
            {
                if (currentForwardSpeed + accelerationDeltaTime > shipStats.MovementMaxSpeed.ModifiedValue)
                {
                    currentForwardSpeed = shipStats.MovementMaxSpeed.ModifiedValue;
                }
                else
                {
                    currentForwardSpeed += accelerationDeltaTime;
                }
            }

            float deltaTimeAngleToChange = angleToChange * deltaTime;
            float deltaTimeCurrentForwardSpeed = currentForwardSpeed * deltaTime;

            currentForwardAngle += deltaTimeAngleToChange;

            Vector3 newRotation = movementTransform.rotation.eulerAngles;

            Vector3 newPosition = movementTransform.position;

            newPosition += movementTransform.up * deltaTimeCurrentForwardSpeed;

            movementTransform.position = newPosition;
            movementTransform.rotation = Quaternion.Euler(newRotation.x, newRotation.y, currentForwardAngle);
        }

        private void DebugInput()
        {
            if(Input.GetKey("a"))
            {
                directionSelectionState.LastSelectedDirecitonNormalizedValue -= 0.5f * Time.deltaTime;
            }

            if (Input.GetKey("d"))
            {
                directionSelectionState.LastSelectedDirecitonNormalizedValue += 0.5f * Time.deltaTime;
            }
        }
    }
}
