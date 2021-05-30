using Playground.Content.LoadingScreen.UI;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class SetLoadingTokenAsCompletedInstruction
    {
        private readonly ILoadingToken loadingToken;

        public SetLoadingTokenAsCompletedInstruction(
            ILoadingToken loadingToken
            )
        {
            this.loadingToken = loadingToken;
        }

        public void Execute()
        {
            loadingToken.Complete();
        }
    }
}
