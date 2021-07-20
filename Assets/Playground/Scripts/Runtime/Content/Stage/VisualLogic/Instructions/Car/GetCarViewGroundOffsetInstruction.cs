using Playground.Content.Stage.VisualLogic.View.Car;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class GetCarViewGroundOffsetInstruction
    {
        private readonly CarViewRepository carViewRepository;

        public GetCarViewGroundOffsetInstruction(
            CarViewRepository carViewRepository
            )
        {
            this.carViewRepository = carViewRepository;
        }

        public Vector3 Execute()
        {
            if(carViewRepository.Item.GroundPosition == null)
            {
                UnityEngine.Debug.LogError($"Tried to get {carViewRepository.Item.GroundPosition} for car " +
                    $"with id {carViewRepository.Item.TypeId} but it was null at {nameof(GetCarViewGroundOffsetInstruction)}");
                return Vector3.zero;
            }

            return carViewRepository.Item.transform.position - carViewRepository.Item.GroundPosition.transform.position;
        }
    }
}
