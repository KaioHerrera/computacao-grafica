using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 2f, -6f);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;
        Vector3 desired = target.position + offset;
        target.position = Vector3.Lerp(target.position, desired, Time.deltaTime * smoothSpeed);
        target.LookAt(target.position + Vector3.up * 1.2f);
    }
}
