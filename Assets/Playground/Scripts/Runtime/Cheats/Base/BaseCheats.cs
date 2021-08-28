using System.ComponentModel;

namespace Playground.Cheats
{
    public class BaseCheats
    {
        [Category("Language")] 
        public void SetNextLanguage()
        {
            SetNextLanguageCheat.Execute();
        }
    }
}
