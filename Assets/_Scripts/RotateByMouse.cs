using UnityEngine;

public class RotateByMouse : MonoBehaviour
{
    public float angleOverDistance = 2f;
    public Transform cameraHolder; // Empty object chứa Camera
    public float minPitch = -80f;
    public float maxPitch = 80f;

    private float pitch = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        UpdateYaw();
        UpdatePitch();
    }

    private void UpdateYaw()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float yaw = mouseX * angleOverDistance;
        transform.Rotate(0, yaw, 0); 
    }

    private void UpdatePitch()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaPitch = -mouseY * angleOverDistance;
        pitch = Mathf.Clamp(pitch + deltaPitch, minPitch, maxPitch);

        cameraHolder.localEulerAngles = new Vector3(pitch, 0, 0); 
    }
}
