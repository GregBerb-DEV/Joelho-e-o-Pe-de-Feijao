using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataforma : MonoBehaviour
{
    public GameObject plataforma;
    public GameObject[] pontos;

    public float velocidade = 5f;
    public float espera = 1f;

    public bool loop = true;
    Transform transform;
    int i = 0;
    float proxTempo;
    bool seMovendo = true;

    // Start is called before the first frame update
    void Start()
    {
        transform = plataforma.transform;
        proxTempo = 0;
        seMovendo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= proxTempo)
        {
            movimento();
        }
    }

    void movimento()
    {
        if((pontos.Length != 0) && seMovendo)
        {
            transform.position = Vector3.MoveTowards(transform.position, pontos[i].transform.position,
                                                    velocidade * Time.deltaTime);
        }
        if(Vector3.Distance(pontos[i].transform.position,transform.position) < 0.001f)
        {
            i++;
            proxTempo = Time.time + espera;
        }
        if (i >= pontos.Length)
        {
            if (loop)
            {
                i = 0;
            }
            else
            {
                seMovendo = false;
            }
        }
    }
}
