using Juce.CoreUnity.Files;
using Juce.CoreUnity.Service;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Services
{
    public class UserService : IService
    {
        private event Action<UserData> saveAction;
        private event Action<UserData> loadAction;

        public UserData UserData { get; private set; }

        public void Init()
        {
            TryGenerateUserData();
        }

        public void CleanUp()
        {

        }

        public void Register(Action<UserData> saveAction, Action<UserData> loadAction)
        {
            this.saveAction += saveAction;
            this.loadAction += loadAction;
        }

        public void Unregister(Action<UserData> saveAction, Action<UserData> loadAction)
        {
            this.saveAction -= saveAction;
            this.loadAction -= loadAction;
        }

        public async Task Save(CancellationToken cancellationToken)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.Formatting = Formatting.Indented;

            TryGenerateUserData();

            saveAction?.Invoke(UserData);

            try
            {
                string finalPath = UserDataUtils.GetUserDataPath();

                string dataString = JsonConvert.SerializeObject(UserData, settings);
                byte[] dataBytes = Encoding.ASCII.GetBytes(dataString);

                await FileUtils.SaveBytesAsync(finalPath, dataBytes, cancellationToken);

                UnityEngine.Debug.Log($"User data saved \n {UserData}");
            }
            catch(Exception exception)
            {
                UnityEngine.Debug.LogError($"Error saving user data with " +
                    $"the following exception {exception}");
            }
        }

        public async Task Load(CancellationToken cancellationToken)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.Formatting = Formatting.Indented;

            string finalPath = UserDataUtils.GetUserDataPath();

            try
            {
                byte[] bytes = await FileUtils.LoadBytesAsync(finalPath, cancellationToken);

                if (bytes != null)
                {
                    string result = Encoding.UTF8.GetString(bytes);

                    UserData = JsonConvert.DeserializeObject(result) as UserData;

                    UnityEngine.Debug.Log($"User data loaded \n {UserData}");
                }
                else
                {
                    UnityEngine.Debug.Log($"User data not found. Creating with default values");
                }

                TryGenerateUserData();

                loadAction?.Invoke(UserData);
            }
            catch (Exception exception)
            {
                UnityEngine.Debug.LogError($"Error loading user data " +
                    $"with the following exception {exception}");
            }

            TryGenerateUserData();
        }

        private void TryGenerateUserData()
        {
            if(UserData != null)
            {
                return;
            }

            UserData = new UserData();
        }
    }
}
