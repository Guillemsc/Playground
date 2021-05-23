using UnityEngine;

[CreateAssetMenu(fileName = "CharacterMouseLookConfiguration", menuName = "Playground/CharacterMouseLookConfiguration", order = 1)]
public class CharacterMouseLookConfiguration : ScriptableObject
{
    [SerializeField] [Min(0)] private float mouseSensitivity = default;

    public float MouseSensitivity => mouseSensitivity;
}
