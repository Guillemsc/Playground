using Juce.CoreUnity.Service;
using Playground.Content.Stage.Setup;
using Playground.Services;
using UnityEngine;

namespace Playground.Utils.Materials
{
    public class FastReloadStageCheat : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown("r"))
            {
                bool found = ServicesProvider.TryGetService(out FlowService flowService);

                if(!found)
                {
                    return;
                }

                flowService.FlowUseCases.ReloadStageUseCase.Execute();
            }
        }
    }
}
