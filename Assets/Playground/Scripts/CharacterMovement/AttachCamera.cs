using UnityEngine;

public class AttachCamera : MonoBehaviour
{
    [SerializeField] private Vector2 orientation = default;
    [SerializeField] private Camera cameraToAttach = default;
    [SerializeField] private Transform parent = default;

    private void Awake()
    {
        cameraToAttach.gameObject.transform.SetParent(parent);
        cameraToAttach.transform.localPosition = Vector3.zero;
        cameraToAttach.transform.localRotation = parent.localRotation;
    }

}
