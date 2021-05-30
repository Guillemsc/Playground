using UnityEngine;

namespace Playground.Scripts.CharacterMovement
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private DefaultCharacterMovementConfiguration characterMovementConfiguration = default;
        [SerializeField] private CharacterController characterController = default;
        [SerializeField] private Transform groundedRaycastPosition = default;
        [SerializeField] [Min(0)] private float groundedRaycastLength = default;

        private ICharacterMovementBehaviour characterMovementBehaviour;

        private void Awake()
        {
            characterMovementBehaviour = new DefaultCharacterMovementBehaviour(characterMovementConfiguration);
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 forwardDirection = new Vector3(characterController.transform.forward.x, 0, characterController.transform.forward.z);

            bool found = Physics.Raycast(groundedRaycastPosition.position, Vector3.down, out RaycastHit raycastHit, groundedRaycastLength);
            Debug.DrawRay(groundedRaycastPosition.position, Vector3.down * groundedRaycastLength, found ? Color.green : Color.red);

            characterMovementBehaviour.BeginFrame(forwardDirection, Vector3.down);

            if (!found)
            {
                characterMovementBehaviour.MoveDown();
            }

            //bool yPositionDecreased = yPosition > characterController.transform.position.y;
            //yPosition = characterController.transform.position.y;

            //if (yPositionDecreased)
            //{
            //    verticalVelocity += characterMovementConfiguration.Gravity * Time.deltaTime;
            //}
            //else
            //{
            //    verticalVelocity = characterMovementConfiguration.MinYVelocity;
            //}

            //Vector3 movement = Vector3.zero;

            if (Input.GetKey("w"))
            {
                characterMovementBehaviour.MoveForward();
            }


            if (Input.GetKey("s"))
            {
                characterMovementBehaviour.MoveBackward();
            }

            if (Input.GetKey("a"))
            {
                characterMovementBehaviour.MoveLeft();
            }

            if (Input.GetKey("d"))
            {
                characterMovementBehaviour.MoveRight();
            }

            characterMovementBehaviour.EndFrame(out Vector3 velocity);

            //if (movement.normalized != Vector3.zero)
            //{
            //    horizontalVelocity += characterMovementConfiguration.Acceleration * Time.deltaTime;

            //    lastMovement = movement.normalized;
            //}
            //else
            //{
            //    horizontalVelocity -= characterMovementConfiguration.Acceleration * Time.deltaTime;

            //    movement += lastMovement;
            //}

            //if (horizontalVelocity > characterMovementConfiguration.MaxHorizontalVelociy)
            //{
            //    horizontalVelocity = characterMovementConfiguration.MaxHorizontalVelociy;
            //}

            //if (horizontalVelocity < 0)
            //{
            //    horizontalVelocity = 0;
            //}

            //if (verticalVelocity > characterMovementConfiguration.MaxYVelocity)
            //{
            //    verticalVelocity = characterMovementConfiguration.MaxYVelocity;
            //}

            //movement = movement.normalized * horizontalVelocity * Time.deltaTime;

            //Vector3 gravity = Vector3.down * verticalVelocity;

            //Vector3 finalMovement = gravity + movement;

            characterController.Move(velocity);
        }
    }
}
