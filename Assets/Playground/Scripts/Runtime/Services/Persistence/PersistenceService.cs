using Playground.Persistence;
using Playground.Utils.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Services.Persistence
{
    public class PersistenceService : IPersistenceService
    {
        public SerializableData<UserData> UserDataSerializableData { get; private set; }
        public SerializableData<ProgressData> ProgressDataSerializableData { get; private set; }

        public PersistenceService()
        {
            UserDataSerializableData = new SerializableData<UserData>(UserData.LocalPath);
            ProgressDataSerializableData = new SerializableData<ProgressData>(ProgressData.LocalPath);
        }

        public async Task LoadAll(CancellationToken cancellationToken)
        {
            await UserDataSerializableData.Load(cancellationToken);
            await ProgressDataSerializableData.Load(cancellationToken);
        }
    }
}
