using SRDebugger;
using UnityEngine;

namespace Playground.Utils.Materials
{
    public class OpenCheats : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                SRDebug.Instance.ShowDebugPanel(DefaultTabs.Options);
            }
        }
    }
}
