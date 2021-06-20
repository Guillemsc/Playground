using Playground.Services;

namespace Playground.Content.Meta.UI.CarsLibrary
{
    public class CarSelectedUseCase : ICarSelectedUseCase
    {
        private readonly UserService userService;

        public CarSelectedUseCase(
            UserService userService
            )
        {
            this.userService = userService;
        }

        public void Execute(string carTypeId)
        {
            userService.UserData.SelectedCarTypeId = carTypeId;
        }
    }
}
