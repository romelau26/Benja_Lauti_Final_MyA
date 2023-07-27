using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSin : IAdvance
{
    Transform _transform;
    float _speed;
    public MovementSin(Transform transform, float speed)
    {
        _transform = transform;
        _speed = speed;
    }
    public void Movement()
    {
        Vector3 pos = _transform.position;
        float sin = Mathf.Sin(pos.z);
        pos.x=sin;
        _transform.position = pos;
    }
}
