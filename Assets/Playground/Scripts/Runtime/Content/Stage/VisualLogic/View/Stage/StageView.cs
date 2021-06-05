using Cinemachine;
using Playground.Content.Stage.VisualLogic.View.CheckPoints;
using Playground.Content.Stage.VisualLogic.View.Scenario;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.View.Stage
{
    public class StageView : MonoBehaviour
    {
        [SerializeField] private ScenarioView scenarioView = default;
        [SerializeField] private CinemachinePath cinemachinePath = default;
        [SerializeField] private CheckPointsView checkPointsView = default;
        [SerializeField] private Transform carStartPosition = default;
        [SerializeField] private FinishLineView finishLineView = default;

        public ScenarioView ScenarioView => scenarioView;
        public CinemachinePath CinemachinePath => cinemachinePath;
        public CheckPointsView CheckPointsView => checkPointsView;
        public Transform CarStartPosition => carStartPosition;
        public FinishLineView FinishLineView => finishLineView;
    }
}
