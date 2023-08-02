using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAttack : IMovement
{
    Transform _bossShip;
    float _speed;

    public FinalAttack(Transform bossShip, float speed)
    {
        _bossShip = bossShip;
        _speed = speed;
    }

    public void Movement()
    {
        _bossShip.position = new Vector3(0, 2, 0);
    }
}
