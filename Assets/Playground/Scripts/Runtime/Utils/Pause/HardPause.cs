using UnityEngine;

namespace Playground.Debug
{
    public class HardPause : MonoBehaviour
    {
        private bool paused = false;

        void Update()
        {
            if(Input.GetKeyDown("p"))
            {
                TogglePause();
            }
        }

        private void TogglePause()
        {
            if(paused)
            {
                Time.timeScale = 1.0f;

                paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;

                paused = true;
            }
        }
    }
}
