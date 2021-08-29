using Playground.Contexts.Stage;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases.LoadStageContext
{
    public class LoadStageContextUseCase : ILoadStageContextUseCase
    {
        public Task Execute()
        {
            return StageContextLoader.Load();
        }
    }
}
