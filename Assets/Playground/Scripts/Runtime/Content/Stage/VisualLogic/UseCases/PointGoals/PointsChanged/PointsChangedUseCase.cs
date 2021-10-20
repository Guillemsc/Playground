using Juce.Core.Sequencing;
using Playground.Content.Stage.VisualLogic.Sequencing;
using Playground.Content.Stage.VisualLogic.State;
using Playground.Content.Stage.VisualLogic.UseCases.SetPointGoalAsCollected;
using Playground.Content.StageUI.UI.Points;

namespace Playground.Content.Stage.VisualLogic.UseCases.PointsChanged
{
    public class PointsChangedUseCase : IPointsChangedUseCase
    {
        private readonly ISequencerTimelines<StageTimeline> sequencerTimelines;
        private readonly PointsState pointsState;
        private readonly IPointsUIInteractor pointsUIInteractor;
        private readonly ISetPointGoalAsCollectedUseCase setPointGoalAsCollectedUseCase;

        public PointsChangedUseCase(
            ISequencerTimelines<StageTimeline> sequencerTimelines,
            PointsState pointsState,
            IPointsUIInteractor pointsUIInteractor,
            ISetPointGoalAsCollectedUseCase setPointGoalAsCollectedUseCase
            )
        {
            this.sequencerTimelines = sequencerTimelines;
            this.pointsState = pointsState;
            this.pointsUIInteractor = pointsUIInteractor;
            this.setPointGoalAsCollectedUseCase = setPointGoalAsCollectedUseCase;
        }

        public void Execute(int currentPoints)
        {
            ISequencer sequencer = sequencerTimelines.GetOrCreateTimeline(StageTimeline.Main);

            sequencer.Play(() => Run(currentPoints));
        }

        public void Run(int currentPoints)
        {
            pointsState.CurrentPoints = currentPoints;

            pointsUIInteractor.SetPoints(currentPoints);

            setPointGoalAsCollectedUseCase.Execute(pointsState.LastCollectedPointIndex);
        }
    }
}
