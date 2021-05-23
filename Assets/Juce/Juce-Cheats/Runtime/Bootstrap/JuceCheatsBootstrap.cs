using UnityEngine;

namespace Juce.Cheats.Bootstrap
{
    public class JuceCheatsBootstrap : MonoBehaviour
    {
        [SerializeField] private JuceCheatsPanel panelPrefab = default;

        private void Awake()
        {
            GameObject panelInstance = Instantiate(panelPrefab.gameObject);

            DontDestroyOnLoad(panelInstance);

            Destroy(gameObject);
        }
    }
}
