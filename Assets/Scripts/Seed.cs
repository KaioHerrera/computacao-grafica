
using UnityEngine;

public class Seed : MonoBehaviour
{
    public int points = 10;
    public GameObject treePrefab;
    public float rotateSpeed = 45f;

    private bool collected = false;

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }

    public void Collect()
    {
        if (collected) return;
        collected = true;
        GameManager.Instance.AddScore(points);
        SpawnTree();
        Destroy(gameObject);
    }

    private void SpawnTree()
    {
        if (treePrefab == null) return;
        Vector3 spawnPos = transform.position + Vector3.back * 2f; // spawn slightly behind
        GameObject.Instantiate(treePrefab, spawnPos, Quaternion.identity);
    }
}
