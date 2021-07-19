using System.Collections.Generic;

namespace Playground.Shared.UseCases
{
    public class NopGetOwnedCarsUseCase : IGetOwnedCarsUseCase
    {
        public List<string> Execute()
        {
            List<string> ret = new List<string>();

            return ret;
        }
    }
}
