using UnityEngine;

public class WheelSynchronizer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private WheelCollider wheelCollider = default;
    [SerializeField] private Transform wheelTransform = default;

    [Header("Offsets")]
    [SerializeField] private Vector3 positionOffset = default;
    [SerializeField] private Vector3 rotationOffset = default;

    // Update is called once per frame
    void Update()
    {
        wheelCollider.GetWorldPose(out Vector3 position, out Quaternion rotation);

        wheelTransform.position = position;
        wheelTransform.rotation = rotation * Quaternion.Euler(rotationOffset);

        wheelTransform.localPosition += positionOffset;
    }
}
