using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinShip : BasicStats
{
    [SerializeField] Transform finalPos;
    IAdvance _sinAdvance;
    IAdvance _currentAdvance;
    [SerializeField]float curveMove;
    private void Awake()
    {
        _sinAdvance = new MovementSin(transform,_movementSpeed,curveMove);
        _currentAdvance = _sinAdvance;
    }
    // Update is called once per frame
    void Update()
    {
        _currentAdvance.Movement();
    }
}
