using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Playground.Utils.Addressable
{
    public static class AddressablesUtils
    {
        public static Task<T> Load<T>(string path)
        {
            AsyncOperationHandle<T> asyncOperation = Addressables.LoadAssetAsync<T>(path);

            return asyncOperation.Task;
        }
    }
}
