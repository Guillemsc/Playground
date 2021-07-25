using System.Collections.Generic;

namespace Playground.Shared.UseCases
{
    public class NopIsCarOwnedUseCase : IIsCarOwnedUseCase
    {
        public bool Execute(string carTypeId)
        {
            return false;
        }
    }
}
