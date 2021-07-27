using UnityEngine;

public class FlyCameraCheat : MonoBehaviour
{
    private float mainSpeed = 10.0f; //regular speed
    private float shiftAdd = 10.0f; //multiplied by how long shift is held.  Basically running
    private float maxShift = 100.0f; //Maximum speed when holdin gshift
    private float camSens = 0.15f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun = 1.0f;

    private float cameraNearPlaneSpeed = 1.0f;

    private Camera usingCamera;

    private void Start()
    {
        TryGetCameraComponent();

        lastMouse = Input.mousePosition;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
            transform.eulerAngles = lastMouse;
        }

        UpdateCameraFov();

        lastMouse = Input.mousePosition;
        //Mouse  camera angle done.  

        //Keyboard commands
        float f = 0.0f;
        Vector3 p = GetBaseInput();
        if (p.sqrMagnitude > 0)
        { // only move while a direction key is pressed
            if (Input.GetKey(KeyCode.LeftShift))
            {
                totalRun += Time.deltaTime;
                p = p * totalRun * shiftAdd;
                p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
                p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
                p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
            }
            else
            {
                totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
                p = p * mainSpeed;
            }

            p = p * Time.deltaTime;
            Vector3 newPosition = transform.position;
            if (Input.GetKey(KeyCode.Space))
            { //If player wants to move on X and Z axis only
                transform.Translate(p);
                newPosition.x = transform.position.x;
                newPosition.z = transform.position.z;
                transform.position = newPosition;
            }
            else
            {
                transform.Translate(p);
            }
        }
    }

    private Vector3 GetBaseInput()
    { 
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }

    private void UpdateCameraFov()
    {
        if(usingCamera == null)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            float newNearClipPlane = usingCamera.nearClipPlane - cameraNearPlaneSpeed * Time.deltaTime;
            usingCamera.nearClipPlane = Mathf.Max(newNearClipPlane, 0.01f);
        }
        else if(Input.GetKey(KeyCode.X))
        {
            usingCamera.nearClipPlane += cameraNearPlaneSpeed * Time.deltaTime;
        }
    }

    private void TryGetCameraComponent()
    {
        if(usingCamera != null)
        {
            return;
        }

        usingCamera = gameObject.GetComponent<Camera>();
    }
}