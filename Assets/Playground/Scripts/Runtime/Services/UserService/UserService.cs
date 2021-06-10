using Juce.CoreUnity.Service;

namespace Playground.Services
{
    public class UserService : IService
    {
        public UserData UserData { get; } = new UserData();

        public UserService()
        {
      
        }

        public void Init()
        {

        }

        public void CleanUp()
        {

        }
    }
}
