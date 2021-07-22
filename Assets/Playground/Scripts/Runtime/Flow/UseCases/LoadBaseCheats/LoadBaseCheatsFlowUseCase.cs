using Playground.Cheats;

namespace Playground.Flow.UseCases
{
    public class LoadBaseCheatsFlowUseCase : ILoadBaseCheatsFlowUseCase
    {
        public void Execute()
        {
            SRDebug.Instance.AddOptionContainer(new BaseCheats());
        }
    }
}
