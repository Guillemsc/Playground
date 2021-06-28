using Juce.CoreUnity.Service;
using Playground.Persistence;
using Playground.Utils.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Services
{
    public class PersistenceService : IService
    {
        public SerializableData<UserData> UserDataSerializableData { get; private set; }
        public SerializableData<ProgressData> ProgressDataSerializableData { get; private set; }

        public void Init()
        {
            UserDataSerializableData = new SerializableData<UserData>(UserData.LocalPath);
            ProgressDataSerializableData = new SerializableData<ProgressData>(ProgressData.LocalPath);
        }

        public void CleanUp()
        {

        }

        public async Task LoadAll(CancellationToken cancellationToken)
        {
            await UserDataSerializableData.Load(cancellationToken);
            await ProgressDataSerializableData.Load(cancellationToken);
        }
    }
}
