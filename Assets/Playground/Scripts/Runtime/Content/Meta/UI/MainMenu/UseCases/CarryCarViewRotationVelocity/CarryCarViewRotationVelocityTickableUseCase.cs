using Playground.Configuration.MainMenu;
using UnityEngine;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class CarryCarViewRotationVelocityTickableUseCase : ICarryCarViewRotationVelocityTickableUseCase
    {
        private readonly MainMenuConfiguration mainMenuConfiguration;
        private readonly CarViewRotationData carViewRotationData;
        private readonly IRotateCarViewUseCase rotateCarViewUseCase;

        public CarryCarViewRotationVelocityTickableUseCase(
            MainMenuConfiguration mainMenuConfiguration,
            CarViewRotationData carViewRotationData,
            IRotateCarViewUseCase rotateCarViewUseCase
            )
        {
            this.mainMenuConfiguration = mainMenuConfiguration;
            this.carViewRotationData = carViewRotationData;
            this.rotateCarViewUseCase = rotateCarViewUseCase;
        }

        public void Tick()
        {
            float maxSpeed = carViewRotationData.CurrentCarriedRotationSpeed * mainMenuConfiguration.CarCarryRotationMultiplier;

            if (carViewRotationData.IsManuallyRotating)
            {
                return;
            }

            if(carViewRotationData.CurrentCarriedRotationDecelerationTime > mainMenuConfiguration.CarCarryRotationDecelerationTime)
            {
                return;
            }

            carViewRotationData.CurrentCarriedRotationDecelerationTime += Time.deltaTime;

            float normalizedCurrentTime = carViewRotationData.CurrentCarriedRotationDecelerationTime 
                / mainMenuConfiguration.CarCarryRotationDecelerationTime;

            float normalizedSpeedValue = 1 - mainMenuConfiguration.CarCarryRotationDecelerationCurve.Evaluate(normalizedCurrentTime);

            float currentSpeedValue = maxSpeed * normalizedSpeedValue;

            rotateCarViewUseCase.Execute(currentSpeedValue);
        }
    }
}
