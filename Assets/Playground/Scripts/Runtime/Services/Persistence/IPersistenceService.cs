using Playground.Persistence;
using Playground.Utils.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Services.Persistence
{
    public interface IPersistenceService
    {
        SerializableData<UserData> UserDataSerializableData { get; }
        SerializableData<ProgressData> ProgressDataSerializableData { get; }

        Task LoadAll(CancellationToken cancellationToken);
    }
}
