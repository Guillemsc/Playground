using UnityEngine;

namespace Playground.Scripts.CharacterMovement
{
    public class DefaultCharacterMovementBehaviour : ICharacterMovementBehaviour
    {
        private readonly DefaultCharacterMovementConfiguration configuration;

        private Vector3 currentFowardDirection;
        private Vector3 currentDownwardDirection;

        private Vector3 currentLeftDirection;
        private Vector3 currentRightDirection;
        private Vector3 currentBackwardDirection;

        private bool applyDown;

        private Vector3 lastFrameFinalMovementDirection;
        private Vector3 lastFrameUsedFinalMovementDirection;

        private Vector3 finalMovementDirection;
        private bool finalMovementDirectionUsed;

        private Vector3 currentHorizontalVelocity;
        private float currentVerticalVelocity;

        public DefaultCharacterMovementBehaviour(DefaultCharacterMovementConfiguration defaultCharacterMovementConfiguration)
        {
            configuration = defaultCharacterMovementConfiguration;
        }

        public void BeginFrame(Vector3 forwardDirection, Vector3 downwardDirection)
        {
            currentFowardDirection = forwardDirection;
            currentDownwardDirection = downwardDirection;

            currentLeftDirection = currentFowardDirection.PerpendicularCounterClockwiseXZ();
            currentRightDirection = currentBackwardDirection.PerpendicularCounterClockwiseXZ();
            currentBackwardDirection = -currentFowardDirection;

            applyDown = false;

            finalMovementDirection = Vector3.zero;
            finalMovementDirectionUsed = false;
        }

        public void EndFrame(out Vector3 velocity)
        {
            finalMovementDirection.Normalize();

            EndFrameHorizontal();
            EndFrameVertical();

            lastFrameFinalMovementDirection = finalMovementDirection;

            if(finalMovementDirectionUsed)
            {
                lastFrameUsedFinalMovementDirection = finalMovementDirection;
            }

            Vector3 horizontalVelocity = CalculateHorizontalVelocity();

            velocity = new Vector3(horizontalVelocity.x, currentVerticalVelocity, horizontalVelocity.z);
        }

        public void MoveForward()
        {
            finalMovementDirection += currentFowardDirection;

            finalMovementDirectionUsed = true;
        }

        public void MoveBackward()
        {
            finalMovementDirection += currentBackwardDirection;

            finalMovementDirectionUsed = true;
        }

        public void MoveLeft()
        {
            finalMovementDirection += currentLeftDirection;

            finalMovementDirectionUsed = true;
        }

        public void MoveRight()
        {
            finalMovementDirection += currentRightDirection;

            finalMovementDirectionUsed = true;
        }

        public void MoveDown()
        {
            applyDown = true;
        }

        private void EndFrameHorizontal()
        {
            if (finalMovementDirection == Vector3.zero)
            {
                currentHorizontalVelocity += -currentHorizontalVelocity.normalized * configuration.HorizontalDeceleration * Time.deltaTime;
            }
            else
            {
                currentHorizontalVelocity += lastFrameUsedFinalMovementDirection * configuration.HorizontalAcceleration * Time.deltaTime;
            }

            if (currentHorizontalVelocity.magnitude > configuration.MaxHorizontalVelociy)
            {
                currentHorizontalVelocity = currentHorizontalVelocity.normalized * configuration.MaxHorizontalVelociy;
            }
        }

        private void EndFrameVertical()
        {
            if(applyDown)
            {
                currentVerticalVelocity += -configuration.VerticalAcceleration * Time.deltaTime;
            }
            else
            {
                currentVerticalVelocity = 0;
            }

            if (currentVerticalVelocity < -configuration.MaxVerticalVelocity)
            {
                currentVerticalVelocity = -configuration.MaxVerticalVelocity;
            }
        }

        private Vector3 CalculateHorizontalVelocity()
        {
            Vector3 horizontalVelocity = currentHorizontalVelocity;

            return horizontalVelocity;
        }
    }
}
