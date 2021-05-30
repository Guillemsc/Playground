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
            carViewRepository.CarView.transform.position = transform.position;
            carViewRepository.CarView.transform.rotation = transform.rotation;
        }
    }
}
