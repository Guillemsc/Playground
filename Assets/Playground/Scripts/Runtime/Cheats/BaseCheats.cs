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

        [Category("Cars")]
        public void UnlockAllCars()
        {
            UnlockAllCarsCheat.Execute(default).RunAsync();
        }

        [Category("Cars")]
        public void LockAllCars()
        {
            LockAllCarsCheat.Execute(default).RunAsync();
        }

        [Category("Soft Currency")]
        public void RemoveAllSoftCurrency()
        {
            RemoveAllSoftCurrencyCheat.Execute(default).RunAsync();
        }

        [Category("Soft Currency")]
        public void AddSoftCurrency()
        {
            AddSoftCurrencyCheat.Execute(default).RunAsync();
        }
    }
}
