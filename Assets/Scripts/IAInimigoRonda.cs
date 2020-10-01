using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAInimigoRonda : MonoBehaviour
{
    public GameObject inimigo;

    public GameObject[] pontos;

    public float velocidade = 5f;
    public float espera = 2f;

    public bool loop = true;
    public bool atacando = false;

    private Transform transform;
    int i = 0;
    float proxTempo;
    bool seMovendo = true;

    Animator animator;
    Saude saude;

    // Start is called before the first frame update
    void Start()
    {
        transform = inimigo.transform;
        proxTempo = 0f;
        seMovendo = true;
        animator = inimigo.GetComponent<Animator>();
        saude = gameObject.GetComponent<Saude>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!saude.morto)
        {
            if(Time.time >= proxTempo)
            {
                if (!seMovendo)
                {
                    Vector2 escala = transform.localScale;
                    escala.x = escala.x * -1;
                    transform.localScale = escala;
                    seMovendo = true;
                }
            }
            if (!atacando)
            {
                movimenta();
            }
        }
    }

    void movimenta()
    {

        if((pontos.Length != 0) && (seMovendo))
        {
            transform.position = Vector3.MoveTowards(transform.position,
                                                       pontos[i].transform.position,
                                                       velocidade * Time.deltaTime);

            animator.SetBool("Running", true);

            if(Vector3.Distance(pontos[i].transform.position, transform.position) <= 0.1)
            {
                i++;
                proxTempo = Time.time + espera;
                seMovendo = false;
                animator.SetBool("Running", false);
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
    void OnTriggerStay2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "Player")
        {
            ataca();
        }
    }
    void ataca()
    {
        if (!atacando)
        {
            animator.SetTrigger("Attack");

        }
    }
}
