using UnityEngine;

[CreateAssetMenu(fileName = "DefaultCharacterMovementConfiguration", menuName = "Playground/DefaultCharacterMovementConfiguration", order = 1)]
public class DefaultCharacterMovementConfiguration : ScriptableObject
{
    [Header("Vertical Acceleration")]
    [SerializeField] [Min(0)] private float horizontalAcceleration = default;
    [SerializeField] [Min(0)] private float horizontalDeceleration = default;

    [Header("Horizontal Acceleration")]
    [SerializeField] [Min(0)] private float verticalAcceleration = default;

    [Header("Velocity")]
    [SerializeField] [Min(0)] private float maxHorizontalVelocity = default;
    [SerializeField] [Min(0)] private float maxVerticalVelocity = default;

    public float VerticalAcceleration => verticalAcceleration;
    public float HorizontalDeceleration => horizontalDeceleration;
    public float HorizontalAcceleration => horizontalAcceleration;
    public float MaxHorizontalVelociy => maxHorizontalVelocity;
    public float MaxVerticalVelocity => maxVerticalVelocity;
}
