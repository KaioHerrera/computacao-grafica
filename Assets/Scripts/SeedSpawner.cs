using UnityEngine;

public class SeedSpawner : MonoBehaviour
{
    [Header("Prefab da Semente")]
    public GameObject seedPrefab;

    [Header("Configurações de Spawn")]
    public int quantidadeInicial = 10;
    public int quantidadeMaxima = 20;
    public float tempoEntreSpawns = 5f;

    [Header("Área de Spawn (tamanho do terreno)")]
    public float limiteX = 2000f;
    public float limiteZ = 2000f;
    public float alturaExtra = 1f;

    private int sementesAtivas = 0;

    private void Start()
    {
        for (int i = 0; i < quantidadeInicial; i++)
        {
            SpawnSeed();
        }

        InvokeRepeating(nameof(SpawnSeed), tempoEntreSpawns, tempoEntreSpawns);
    }

    private void SpawnSeed()
    {
        if (sementesAtivas >= quantidadeMaxima) return;

        float x = Random.Range(0, limiteX);
        float z = Random.Range(0, limiteZ);

        Vector3 pos = new Vector3(x, 0, z);
        float y = Terrain.activeTerrain.SampleHeight(pos);

        pos.y = y + alturaExtra;

        Instantiate(seedPrefab, pos, Quaternion.identity);
        sementesAtivas++;
    }

    public void SeedColetada()
    {
        sementesAtivas--;
        if (sementesAtivas < 0) sementesAtivas = 0;
    }
}
