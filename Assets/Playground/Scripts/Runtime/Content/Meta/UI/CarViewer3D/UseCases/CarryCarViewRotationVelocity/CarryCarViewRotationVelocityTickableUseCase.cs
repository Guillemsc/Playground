using Playground.Configuration.MainMenu;
using UnityEngine;

namespace Playground.Content.Meta.UI.CarViewer3D
{
    public class CarryCarViewRotationVelocityTickableUseCase : ICarryCarViewRotationVelocityTickableUseCase
    {
        private readonly CarViewer3DConfiguration carViewer3DConfiguration;
        private readonly CarViewRotationData carViewRotationData;
        private readonly IRotateCarViewUseCase rotateCarViewUseCase;

        public CarryCarViewRotationVelocityTickableUseCase(
            CarViewer3DConfiguration carViewer3DConfiguration,
            CarViewRotationData carViewRotationData,
            IRotateCarViewUseCase rotateCarViewUseCase
            )
        {
            this.carViewer3DConfiguration = carViewer3DConfiguration;
            this.carViewRotationData = carViewRotationData;
            this.rotateCarViewUseCase = rotateCarViewUseCase;
        }

        public void Tick()
        {
            float maxSpeed = carViewRotationData.CurrentCarriedRotationSpeed * carViewer3DConfiguration.CarCarryRotationMultiplier;

            if (carViewRotationData.IsManuallyRotating)
            {
                return;
            }

            if(carViewRotationData.CurrentCarriedRotationDecelerationTime > carViewer3DConfiguration.CarCarryRotationDecelerationTime)
            {
                return;
            }

            carViewRotationData.CurrentCarriedRotationDecelerationTime += Time.deltaTime;

            float normalizedCurrentTime = carViewRotationData.CurrentCarriedRotationDecelerationTime 
                / carViewer3DConfiguration.CarCarryRotationDecelerationTime;

            float normalizedSpeedValue = 1 - carViewer3DConfiguration.CarCarryRotationDecelerationCurve.Evaluate(normalizedCurrentTime);

            float currentSpeedValue = maxSpeed * normalizedSpeedValue;

            rotateCarViewUseCase.Execute(currentSpeedValue);
        }
    }
}
