using Playground.Contexts.Stage;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases.LoadStageUIContext
{
    public class LoadStageUIContextUseCase : ILoadStageUIContextUseCase
    {
        public Task Execute()
        {
            return StageUIContextLoader.Load();
        }
    }
}
