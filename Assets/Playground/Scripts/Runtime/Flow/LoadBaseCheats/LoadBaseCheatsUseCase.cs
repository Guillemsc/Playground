using Playground.Cheats;

namespace Playground.Flow.UseCases.LoadBaseCheats
{
    public class LoadBaseCheatsUseCase : ILoadBaseCheatsUseCase
    {
        public void Execute()
        {
            SRDebug.Instance.AddOptionContainer(new BaseCheats());
        }
    }
}
