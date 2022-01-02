using Assets.Playground.Scripts.Runtime.Cheats.Base.UseCases.SetNextLanguage;
using System.ComponentModel;

namespace Playground.Cheats
{
    public class BaseCheats
    {
        private readonly ISetNextLanguageUseCase setNextLanguageUseCase; 

        public BaseCheats(
            ISetNextLanguageUseCase setNextLanguageUseCase
            )
        {
            this.setNextLanguageUseCase = setNextLanguageUseCase;
        }

        [Category("Language")] 
        public void SetNextLanguage()
        {
            setNextLanguageUseCase.Execute();
        }
    }
}
