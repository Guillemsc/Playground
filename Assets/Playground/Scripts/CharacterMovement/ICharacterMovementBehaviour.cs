using UnityEngine;

namespace Playground.Scripts.CharacterMovement
{
    public interface ICharacterMovementBehaviour
    {
        void BeginFrame(Vector3 forwardDirection, Vector3 downwardDirection);
        void EndFrame(out Vector3 velocity);

        void MoveForward();
        void MoveBackward();
        void MoveLeft();
        void MoveRight();
        void MoveDown();
    }
}
