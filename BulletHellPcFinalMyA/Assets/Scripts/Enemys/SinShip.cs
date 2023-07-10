using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinShip : BasicStats
{
    [SerializeField] Transform finalPos;
    IAdvance _sinAdvance;
    IAdvance _currentAdvance;
    [SerializeField]float curveMove;
    [SerializeField] GameObject ExplotionCam;
    private void Awake()
    {
        _sinAdvance = new MovementSin(transform, curveMove);
        _currentAdvance = _sinAdvance;
    }
    // Update is called once per frame
    void Update()
    {
        _currentAdvance.Movement();
        if(CurrentHealth<=0)
        {
            gameObject.SetActive(false);
            Instantiate(ExplotionCam, transform.position, transform.rotation);
        }
    }
}
