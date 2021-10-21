using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.StageUI.UI.ToasterTexts.UseCases.PlayToasterText
{
    public interface IPlayToasterTextUseCase
    {
        Task Execute(string text, CancellationToken cancellationToken);
    }
}
