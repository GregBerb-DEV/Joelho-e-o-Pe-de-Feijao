using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageKick : MonoBehaviour
{
    public int dano = 5;
    public string tagInimigo = "inimigo";
    public GameObject explosao;

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if(outro.tag == tagInimigo)
        {
            outro.gameObject.GetComponent<Saude>().dano(dano);
        }
        if (explosao){
            Instantiate(explosao, transform.position, transform.rotation);
        }
    }
}
