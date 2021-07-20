using Playground.Content.Stage.VisualLogic.View.Car;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class TeleportCarToTransformInstruction
    {
        private readonly CarViewRepository carViewRepository;
        private readonly Transform transform;
        private readonly Vector3 positionOffset;

        public TeleportCarToTransformInstruction(
            CarViewRepository carViewRepository,
            Transform transform,
            Vector3 positionOffset
            )
        {
            this.carViewRepository = carViewRepository;
            this.transform = transform;
            this.positionOffset = positionOffset;
        }

        public void Execute()
        {
            carViewRepository.Item.transform.position = transform.position + positionOffset;
            carViewRepository.Item.transform.rotation = transform.rotation;
        }
    }
}
