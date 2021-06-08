using Juce.CoreUnity.Contracts;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Viewer3D
{
    public class Viewer3DView : MonoBehaviour
    {
        [SerializeField] private Transform viewerParent = default;

        public Transform Pivot => viewerParent;

        private void Awake()
        {
            Contract.IsNotNull(viewerParent, this);
        }

        public void Show(GameObject gameObject)
        {
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.SetParent(viewerParent, worldPositionStays: false);
        }
    }
}
