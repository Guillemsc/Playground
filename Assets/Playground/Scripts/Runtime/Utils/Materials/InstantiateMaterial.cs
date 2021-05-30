using UnityEngine;

namespace Playground.Utils.UIAnimations
{
    public class InstantiateMaterial : MonoBehaviour
    {
        private void Awake()
        {
            TryInstantiateMaterial();
        }

        private void TryInstantiateMaterial()
        {
            Material material = gameObject.GetComponent<Material>();
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
