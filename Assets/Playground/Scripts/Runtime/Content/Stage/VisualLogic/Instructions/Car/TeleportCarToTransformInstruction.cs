using Playground.Content.Stage.VisualLogic.View.Car;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class TeleportCarToTransformInstruction
    {
        private readonly CarViewRepository carViewRepository;
        private readonly Transform transform;

        public TeleportCarToTransformInstruction(
            CarViewRepository carViewRepository,
            Transform transform
            )
        {
            this.carViewRepository = carViewRepository;
            this.transform = transform;
        }

        public void Execute()
        {
            carViewRepository.Item.transform.position = transform.position;
            carViewRepository.Item.transform.rotation = transform.rotation;
        }
    }
}
