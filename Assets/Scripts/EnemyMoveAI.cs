using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAInimigoRonda : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyGameObject
    [SerializeField]
    private GameObject[] _nodes;
    [SerializeField]
    private float _enemySpeed = 5f;
    [SerializeField]
    private float _waitTimeBetweenLoops = 2f;
    [SerializeField]
    private bool _willLoopNodes = true;
    [SerializeField]
    private bool _isAttacking = false;
    private int _currentNodeIndex = 0;
    private float _nextTimeToMove;
    private bool _isMoving = true;
    private PlayerAnimation _playerAnimation;
    private PlayerHealth _playerHealth;

    void Start()
    {
        _nextTimeToMove = 0f;
        _isMoving = true;
        _playerAnimation = _enemyGameObject.GetComponent<PlayerAnimation>();
        _playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (!_playerHealth.IsDead)
        {
            if (Time.time >= _nextTimeToMove)
            {
                if (!_isMoving)
                {
                    Vector2 enemyScale = transform.localScale;
                    enemyScale.x = enemyScale.x * -1;
                    transform.localScale = enemyScale;
                    _isMoving = true;
                }
            }
            if (!_isAttacking)
            {
                MoveToNextNode();
            }
        }
    }

    void MoveToNextNode()
    {

        if ((_nodes.Length != 0) && (_isMoving))
        {
            transform.position = Vector3.MoveTowards(transform.position,
                                                       _nodes[_currentNodeIndex].transform.position,
                                                       _enemySpeed
                                                 * Time.deltaTime);

            //Setar animação pra correr

            if (Vector3.Distance(_nodes[_currentNodeIndex].transform.position, transform.position) <= 0.1)
            {
                _currentNodeIndex++;
                _nextTimeToMove = Time.time + _waitTimeBetweenLoops
        ;
                _isMoving = false;
                //Setar animação pra andar
            }

            if (_currentNodeIndex >= _nodes.Length)
            {
                if (_willLoopNodes)
                {
                    _currentNodeIndex = 0;
                }
                else
                {
                    _isMoving = false;
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "Player")
        {
            Attack();
        }
    }
    void Attack()
    {
        if (!_isAttacking)
        {
            //Setar animação pra atacar
        }
    }
}
