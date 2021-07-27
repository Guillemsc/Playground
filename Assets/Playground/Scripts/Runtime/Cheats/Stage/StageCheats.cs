using System.ComponentModel;

namespace Playground.Cheats
{
    public class StageCheats
    {
        [Category("Toggle pause")]
        public void TogglePause()
        {
            TogglePauseCheat.Execute();
        }
    }
}
