namespace Playground.Content.Meta.UI.CarPanel
{
    public class SetupViewingCarUseCase : ISetupViewingCarUseCase
    {
        private readonly ViewingCarData viewingCarData;

        public SetupViewingCarUseCase(ViewingCarData viewingCarData)
        {
            this.viewingCarData = viewingCarData;
        }

        public void Execute(string carTypeId)
        {
            viewingCarData.CarTypeId = carTypeId;
        }
    }
}
