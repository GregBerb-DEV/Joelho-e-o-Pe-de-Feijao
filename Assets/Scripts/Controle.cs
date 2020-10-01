using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour
{
    public int velocidade = 10;
    public int forcaDoPulo = 1250;
    public Transform terra;
    public LayerMask chao;

    private float moveX;
    private bool direita = true;
    private bool noChao;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        moveJogador();
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Attack", true);
        }
    }

    private void LateUpdate()
    {
        viraJogador();
    }

    void moveJogador(){
        // Controles
        moveX = Input.GetAxis("Horizontal");
        noChao = Physics2D.Linecast(transform.position, terra.position, chao);

        // Física
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * velocidade,
                                                                     gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetButtonDown("Jump") && noChao)
        {
            pula();
        }
        // animação
        animator.SetBool("OnGround", noChao);
        if(moveX != 0){
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }


    }

    void pula()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcaDoPulo);
    }

    void viraJogador(){
        if(moveX > 0)
        {
            direita = true;
        }
        else if(moveX < 0){
            direita = false;
        }
        Vector2 escala = transform.localScale;
        if((escala.x > 0 && !direita) || (escala.x < 0 && direita)){
            escala.x = escala.x * -1;
            transform.localScale = escala;
        }
    }

    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.tag == "PlataformaMovel")
        {
            this.transform.parent = outro.transform;
        }
    }
    void OnCollisionExit2D(Collision2D outro)
    {
        if (outro.gameObject.tag == "PlataformaMovel")
        {
            this.transform.parent = null;
        }
    }

}
