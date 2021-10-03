using Playground.Contexts.Meta;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases.LoadMetaContext
{
    public class LoadMetaContextUseCase : ILoadMetaContextUseCase
    {
        public Task Execute()
        {
            return MetaContextLoader.Load();
        }
    }
}
