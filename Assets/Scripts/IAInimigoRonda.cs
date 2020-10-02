using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAInimigoRonda : MonoBehaviour
{
    [SerializeField]
    private GameObject inimigo;
    [SerializeField]
    private GameObject[] pontos;
    [SerializeField]
    private float velocidade = 5f;
    [SerializeField]
    private float espera = 2f;
    [SerializeField]
    private bool loop = true;
    [SerializeField]
    private bool atacando = false;
    private int i = 0;
    private float proxTempo;
    private bool seMovendo = true;

    PlayerAnimation _playerAnimation;
    PlayerHealth _playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        proxTempo = 0f;
        seMovendo = true;
        _playerAnimation = inimigo.GetComponent<PlayerAnimation>();
        _playerHealth = gameObject.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerHealth.IsDead)
        {
            if (Time.time >= proxTempo)
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

        if ((pontos.Length != 0) && (seMovendo))
        {
            transform.position = Vector3.MoveTowards(transform.position,
                                                       pontos[i].transform.position,
                                                       velocidade * Time.deltaTime);

            //Setar animação pra correr

            if (Vector3.Distance(pontos[i].transform.position, transform.position) <= 0.1)
            {
                i++;
                proxTempo = Time.time + espera;
                seMovendo = false;
                //Setar animação pra andar
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
            SetBool("Attacking", true)
        }
    }
}
