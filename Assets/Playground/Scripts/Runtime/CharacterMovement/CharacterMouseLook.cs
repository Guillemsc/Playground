using UnityEngine;

public class CharacterMouseLook : MonoBehaviour
{
    [SerializeField] private CharacterMouseLookConfiguration characterMouseLookConfiguration = default;

    [SerializeField] private Transform toRotateX = default;
    [SerializeField] private Transform toRotateY = default;

    private float xRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * characterMouseLookConfiguration.MouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * characterMouseLookConfiguration.MouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        toRotateX.transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        toRotateY.Rotate(Vector3.up * mouseX);
    }
}
