using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteManager : MonoBehaviour, ICharacterSpriteManager
{
    private GameObject _playerSprite;


    void Awake()
    {
        _playerSprite = GetComponentInChildren<SpriteRenderer>().gameObject;
    }

    public void TurnCharacterSprite(float movementHorizontalDirection)
    {
        bool isGoingRight = true;
        Vector2 scale = _playerSprite.transform.localScale;
        if (movementHorizontalDirection > 0)
        {
            isGoingRight = true;
        }
        else if (movementHorizontalDirection < 0)
        {
            isGoingRight = false;
        }
        if ((scale.x > 0 && !isGoingRight) || (scale.x < 0 && isGoingRight))
        {
            scale.x *= -1;
            _playerSprite.transform.localScale = scale;
        }
    }
}
