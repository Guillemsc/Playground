using Juce.CoreUnity.Files;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Utils.Persistence
{
    public class SerializableData<T> where T : class
    {
        private readonly string localPath;

        private Action<T> saveAction;
        private Action<T> loadAction;

        public T Data { get; private set; }

        public SerializableData(string localPath)
        {
            this.localPath = localPath;
        }

        public void Register(Action<T> saveAction, Action<T> loadAction)
        {
            this.saveAction += saveAction;
            this.loadAction += loadAction;
        }

        public void Unregister(Action<T> saveAction, Action<T> loadAction)
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

            saveAction?.Invoke(Data);

            try
            {
                string finalPath = PersistenceDataUtils.GetPersistanceDataFile(localPath);

                string dataString = JsonConvert.SerializeObject(Data, settings);
                byte[] dataBytes = Encoding.UTF8.GetBytes(dataString);

                await FileUtils.SaveBytesAsync(finalPath, dataBytes, cancellationToken);

                UnityEngine.Debug.Log($"{nameof(SerializableData<T>)} {typeof(T).Name} saved \n {Data}");
            }
            catch (Exception exception)
            {
                UnityEngine.Debug.LogError($"Error saving {nameof(SerializableData<T>)} {typeof(T).Name} with " +
                    $"the following exception {exception}");
            }
        }

        public async Task Load(CancellationToken cancellationToken)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.Formatting = Formatting.Indented;

            string finalPath = PersistenceDataUtils.GetPersistanceDataFile(localPath);

            try
            {
                byte[] bytes = await FileUtils.LoadBytesAsync(finalPath, cancellationToken);

                if (bytes != null)
                {
                    string result = Encoding.UTF8.GetString(bytes);

                    Data = JsonConvert.DeserializeObject<T>(result);

                    UnityEngine.Debug.Log($"{nameof(SerializableData<T>)} {typeof(T).Name} loaded \n {Data}");
                }
                else
                {
                    UnityEngine.Debug.Log($"{nameof(SerializableData<T>)} {typeof(T).Name} not found. Creating with default values");
                }

                TryGenerateUserData();

                loadAction?.Invoke(Data);
            }
            catch (Exception exception)
            {
                UnityEngine.Debug.LogError($"Error loading {nameof(SerializableData<T>)} {typeof(T).Name} " +
                    $"with the following exception {exception}");
            }

            TryGenerateUserData();
        }

        private void TryGenerateUserData()
        {
            if (Data != null)
            {
                return;
            }

            Data = Activator.CreateInstance<T>();
        }
    }
}
