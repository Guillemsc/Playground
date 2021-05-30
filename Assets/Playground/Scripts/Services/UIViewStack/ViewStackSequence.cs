using Juce.Core.Sequencing;
using Juce.CoreUnity.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Services.ViewStack
{
    public class ViewStackSequence
    {
        private readonly List<Instruction> instructionsToPlay = new List<Instruction>(); 
        private readonly Sequencer sequencer = new Sequencer();

        private readonly RegisteredViewsRepository registeredViewsRepository;
        private readonly ViewContexRepository viewContexRepository;

        public ViewStackSequence(
            RegisteredViewsRepository registeredViewsRepository,
            ViewContexRepository viewContexRepository
            )
        {
            this.registeredViewsRepository = registeredViewsRepository;
            this.viewContexRepository = viewContexRepository;
        }

        public ViewStackSequence Show<T>(bool instantly) where T : UIView
        {
            Type type = typeof(T);

            instructionsToPlay.Add(new ShowUIViewInstruction(
                registeredViewsRepository, 
                viewContexRepository,
                type, 
                instantly
                ));

            return this;
        }

        public ViewStackSequence Hide<T>(bool instantly) where T : UIView
        {
            Type type = typeof(T);

            instructionsToPlay.Add(new HideUIViewInstruction(
                registeredViewsRepository,
                viewContexRepository,
                type,
                instantly
                ));

            return this;
        }

        public Task Execute(CancellationToken cancellationToken)
        {
            foreach(Instruction instruction in instructionsToPlay)
            {
                sequencer.Play(instruction);
            }

            cancellationToken.Register(sequencer.Kill);

            return sequencer.WaitCompletition();
        }

        public void Execute()
        {
            Execute(default).RunAsync();
        }
    }
}
