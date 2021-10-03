using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetupCamera
{
    public interface ISetActionInputDetectionUIVisibleUseCase
    {
        Task Execute(bool visible, bool instantly, CancellationToken cancellationToken);
    }
}
