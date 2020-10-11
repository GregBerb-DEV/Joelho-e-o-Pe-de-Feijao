using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField]
    private GameObject _platformObject;
    [SerializeField]
    private GameObject[] _followNodes = default;

    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _waitTime = 1f;

    [SerializeField]
    private bool _pathLoop = true;
    private int i = 0;
    private float _nextMovementTime;
    private bool isMoving = true;

    void Start()
    {
        _nextMovementTime = 0;
        isMoving = true;
    }

    void FixedUpdate()
    {
        if (Time.time >= _nextMovementTime)
            MovePlatform();
    }

    void MovePlatform()
    {
        MovePlatformToNextNode();
        CheckIfArrivedToNode();

        CheckIfLastNode();
    }

    private void MovePlatformToNextNode()
    {
        if ((_followNodes.Length != 0) && isMoving)
            transform.position = Vector2.MoveTowards(transform.position, _followNodes[i].transform.position, _moveSpeed);
    }

    private void CheckIfArrivedToNode()
    {
        if (Vector2.Distance(_followNodes[i].transform.position, transform.position) < 0.001f)
        {
            i++;
            _nextMovementTime = Time.time + _waitTime;
        }
    }

    private void CheckIfLastNode()
    {
        if (i >= _followNodes.Length)
        {
            if (_pathLoop)
            {
                i = 0;
            }
            else
            {
                isMoving = false;
            }
        }
    }
}
