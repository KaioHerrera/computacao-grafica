using UnityEngine;

public class SeedFloat : MonoBehaviour
{
    public float alturaExtra = 1f;     
    public float amplitude = 0.5f;     
    public float velocidade = 2f;      

    private Vector3 posInicial;

    void Start()
    {
        posInicial = transform.position;
        posInicial.y += alturaExtra; 
        transform.position = posInicial;
    }

    void Update()
    {
        float novaY = posInicial.y + Mathf.Sin(Time.time * velocidade) * amplitude;
        transform.position = new Vector3(transform.position.x, novaY, transform.position.z);
    }
}
