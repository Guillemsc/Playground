using Playground.Contexts.Cameras;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases.LoadCamerasContext
{
    public class LoadCamerasContextUseCase : ILoadCamerasContextUseCase
    {
        public Task Execute()
        {
            return CamerasContextLoader.Load();
        }
    }
}
