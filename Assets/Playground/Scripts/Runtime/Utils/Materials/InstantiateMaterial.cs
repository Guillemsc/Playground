using UnityEngine;

namespace Playground.Utils.Materials
{
    public class InstantiateMaterial : MonoBehaviour
    {
        private void Awake()
        {
            TryInstantiateMaterial();
        }

        private void TryInstantiateMaterial()
        {
            Renderer renderer = gameObject.GetComponent<Renderer>();

            if(renderer == null)
            {
                return;
            }

            Material materialInstance = new Material(renderer.material);
            renderer.material = materialInstance;
        }
    }
}
