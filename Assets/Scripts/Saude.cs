using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saude : MonoBehaviour
{
    public bool morto;
    public int saude = 10;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        morto = false;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(saude <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void dano(int x)
    {
   
        saude -= x;
        if(saude <= 0)
        {
            morto = true;
            animator.SetTrigger("Die");
            StartCoroutine(morre());
        }
    }
    public void danoMax()
    {
        saude = 0;
        morto = true;
        animator.SetTrigger("Die");
        if (gameObject.tag == "Player")
        {
            StartCoroutine(morre());
        }
    }
    IEnumerator morre()
    {
        if (gameObject.tag == "inimigo")
        {
            Destroy(gameObject);
        }
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);



    }
}
