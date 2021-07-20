namespace Playground.Content.Meta.UI.CarViewer3D
{
    public class CarViewer3DUIInteractor 
    {
        private CarViewer3DUIUseCases useCases;

        public CarViewer3DUIInteractor(
            CarViewer3DUIUseCases useCases
            )
        {
            this.useCases = useCases;
        }

        public void Subscribe()
        {
           
        }

        public void Unsubscribe()
        {

        }

        public void ShowCar(string carTypeId)
        {
            ClearCar();

            useCases.ShowCarViewUseCase.Execute(carTypeId);
        }

        public void ClearCar()
        {
            useCases.CleanUpCarViewUseCase.Execute();
        }
    }
}
