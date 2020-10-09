using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAI : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyGameObject = default;
    [SerializeField]
    private GameObject[] _nodes = default;
    [SerializeField]
    private float _enemySpeed = 5f;
    [SerializeField]
    private float _waitTimeBetweenLoops = 2f;
    [SerializeField]
    private bool _willLoopNodes = true;
    private int _currentNodeIndex = 0;
    private float _nextTimeToMove;
    private bool _isMoving = true;
    private EnemyAnimation _enemyAnimation;
    private EnemyHealth _enemyHealth;
    private EnemyAttack _enemyAttack;

    void Start()
    {
        _nextTimeToMove = 0f;
        _isMoving = true;
        _enemyAnimation = GetComponent<EnemyAnimation>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyAttack = GetComponent<EnemyAttack>();

    }

    void Update()
    {
        if (!_enemyHealth.IsDead)
        {
            if (Time.time >= _nextTimeToMove)
            {
                CheckIfTurn();
            }
            if (!_enemyAttack.IsAttacking)
            {
                MoveToNextNode();
            }
        }
    }

    void CheckIfTurn()
    {

        if (!_isMoving)
        {
            Vector2 enemyScale = transform.localScale;
            enemyScale.x = enemyScale.x * -1;
            transform.localScale = enemyScale;
            _isMoving = true;
        }
    }

    void MoveToNextNode()
    {
        if ((_nodes.Length != 0) && (_isMoving))
        {
            transform.position = Vector3.MoveTowards(_enemyGameObject.transform.position, _nodes[_currentNodeIndex].transform.position, _enemySpeed * Time.deltaTime);
            CheckIfIsOnNode();
            CheckIfLoop();
        }
    }

    void CheckIfIsOnNode()
    {
        if (Vector3.Distance(_nodes[_currentNodeIndex].transform.position, _enemyGameObject.transform.position) <= 0.001)
        {
            _currentNodeIndex++;
            _nextTimeToMove = Time.time + _waitTimeBetweenLoops;
            _isMoving = false;
            //Setar animação pra andar
        }
    }
    void CheckIfLoop()
    {

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