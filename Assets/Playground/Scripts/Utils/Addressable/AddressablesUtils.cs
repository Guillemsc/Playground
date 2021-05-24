using Juce.Core.Disposables;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Playground.Utils.Addressable
{
    public static class AddressablesUtils
    {
        public static async Task<IDisposable<T>> Load<T>(string path)
        {
            AsyncOperationHandle<T> asyncOperation = Addressables.LoadAssetAsync<T>(path);

            T result = await asyncOperation.Task;

            return new Disposable<T>(result, () => Addressables.Release(asyncOperation));
        }
    }
}
