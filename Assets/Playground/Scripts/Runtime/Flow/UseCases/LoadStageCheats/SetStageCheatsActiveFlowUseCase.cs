using Playground.Cheats;

namespace Playground.Flow.UseCases
{
    public class SetStageCheatsActiveFlowUseCase : ISetStageCheatsActiveFlowUseCase
    {
        private readonly StageCheats stageCheats = new StageCheats();

        public void Execute(bool active)
        {
            if (active)
            {
                SRDebug.Instance.AddOptionContainer(stageCheats);
            }
            else
            {
                SRDebug.Instance.RemoveOptionContainer(stageCheats);
            }
        }
    }
}
