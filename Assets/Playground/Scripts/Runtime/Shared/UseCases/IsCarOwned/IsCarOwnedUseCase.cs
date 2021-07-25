using System.Collections.Generic;

namespace Playground.Shared.UseCases
{
    public class IsCarOwnedUseCase : IIsCarOwnedUseCase
    {
        private readonly IGetOwnedCarsUseCase getOwnedCarsUseCase;

        public IsCarOwnedUseCase(IGetOwnedCarsUseCase getOwnedCarsUseCase)
        {
            this.getOwnedCarsUseCase = getOwnedCarsUseCase;
        }

        public bool Execute(string carTypeId)
        {
            List<string> ownedCars = getOwnedCarsUseCase.Execute();

            return ownedCars.Contains(carTypeId);
        }
    }
}
