using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Terrain terrain;     // Referência para o terreno
    public Transform player;    // Referência para o player
    public float offsetY = 2f;  // Altura acima do solo

    void Start()
    {
        // Pega a posição atual do player
        Vector3 pos = player.position;

        // Descobre a altura do terreno nesse ponto (X,Z)
        float terrainHeight = terrain.SampleHeight(pos);

        // Posiciona o player acima do solo
        player.position = new Vector3(pos.x, terrainHeight + offsetY, pos.z);
    }
}
