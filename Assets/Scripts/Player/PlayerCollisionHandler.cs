using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    //Tudo isso aqui provavelmente vai mudar
    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.tag == "PlataformaMovel")
        {
            transform.parent = outro.transform;
        }

        // if(outro.GetComponent<IHandleCollision>()){
        //     (outro.GetComponent<IHandleCollision>().HandleCollision();
        // }
    }
    void OnCollisionExit2D(Collision2D outro)
    {
        if (outro.gameObject.tag == "PlataformaMovel")
        {
            transform.parent = null;
        }
    }
}
