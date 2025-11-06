using UnityEngine;

public class CameraMouseLook : MonoBehaviour
{
    public Transform player;           
    public float mouseSensitivity = 200f;
    public float minY = -30f;
    public float maxY = 60f;

    private float rotY = 0f; 
    private float rotX = 0f; 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotY += mouseX;
        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX, minY, maxY);

        player.rotation = Quaternion.Euler(0f, rotY, 0f);
        transform.localRotation = Quaternion.Euler(rotX, 0f, 0f);
    }
}
