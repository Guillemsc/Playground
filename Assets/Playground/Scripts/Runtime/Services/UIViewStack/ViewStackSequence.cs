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

        private readonly UIViewRepository registeredViewsRepository;
        private readonly ViewContexRepository viewContexRepository;
        private readonly ViewQueueRepository viewQueueRepository;
        private readonly UIInteractorRepository uiInteractorRepository;
        private readonly Sequencer sequencer;

        public ViewStackSequence(
            UIViewRepository registeredViewsRepository,
            ViewContexRepository viewContexRepository,
            ViewQueueRepository viewQueueRepository,
            UIInteractorRepository uiInteractorRepository,
            Sequencer sequencer
            )
        {
            this.registeredViewsRepository = registeredViewsRepository;
            this.viewContexRepository = viewContexRepository;
            this.viewQueueRepository = viewQueueRepository;
            this.uiInteractorRepository = uiInteractorRepository;
            this.sequencer = sequencer;
        }

        public ViewStackSequence Show<T>(bool instantly) where T : UIView
        {
            Type type = typeof(T);

            instructionsToPlay.Add(new ShowUIViewInstruction(
                registeredViewsRepository, 
                viewContexRepository,
                uiInteractorRepository,
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
                viewQueueRepository,
                type,
                instantly
                ));

            return this;
        }

        public ViewStackSequence MoveBack<T>() where T : UIView
        {
            Type type = typeof(T);

            instructionsToPlay.Add(new MoveBackUIViewInstruction(
                registeredViewsRepository,
                type
                ));

            return this;
        }

        public ViewStackSequence ShowLast(bool instantly)
        {
            instructionsToPlay.Add(new ShowLastUIViewInstruction(
                registeredViewsRepository,
                viewContexRepository,
                viewQueueRepository,
                uiInteractorRepository,
                behindForeground: false,
                instantly
                ));

            return this;
        }

        public ViewStackSequence ShowLastBehindForeground(bool instantly)
        {
            instructionsToPlay.Add(new ShowLastUIViewInstruction(
                registeredViewsRepository,
                viewContexRepository,
                viewQueueRepository,
                uiInteractorRepository,
                behindForeground: true,
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
