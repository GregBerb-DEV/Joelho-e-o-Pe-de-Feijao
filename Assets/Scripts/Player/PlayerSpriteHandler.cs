using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteHandler : MonoBehaviour
{
    private Vector2 escala;
    private bool isRight = true;

    public void TurnPlayer(float movementDirection)
    {
        escala = transform.localScale;
        if (movementDirection != 0)
            isRight = movementDirection > 0;
        if ((escala.x > 0 && !isRight) || (escala.x < 0 && isRight))
        {
            escala.x *= -1;
            transform.localScale = escala;
        }
    }
}
