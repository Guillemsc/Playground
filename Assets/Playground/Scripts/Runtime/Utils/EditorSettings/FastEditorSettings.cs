using UnityEngine;

namespace Playground.Utils.Materials
{
    public class FastEditorSettings : MonoBehaviour
    {
        [SerializeField] [Range(0, 999)] private int maxFramerate = 999;
        [SerializeField] private bool vSync = default;

#if UNITY_EDITOR
        private void Update()
        {
            SetSettings();
        }
#endif

        private void SetSettings()
        {
            Application.targetFrameRate = maxFramerate;

            if(vSync)
            {
                QualitySettings.vSyncCount = 1;
            }
            else
            {
                QualitySettings.vSyncCount = 0;
            }
        }
    }
}
