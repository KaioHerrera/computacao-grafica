
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damagePoints = 0; // optional: reduce score
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Let PlayerController handle slowdown via OnCollisionEnter
            // Optionally reduce score:
            // GameManager.Instance.AddScore(-damagePoints);
        }
    }
}
