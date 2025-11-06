using UnityEngine;

public class Seed : MonoBehaviour
{
    public int points = 10;

    public void Collect() 
    {
        FindObjectOfType<SeedSpawner>().SeedColetada();
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }
}
