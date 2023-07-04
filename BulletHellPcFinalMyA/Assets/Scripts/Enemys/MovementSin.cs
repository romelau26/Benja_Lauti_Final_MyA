using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSin : IAdvance
{
    Transform _transform;
    float _speed;
    float _acum;
    public MovementSin(Transform transform, float speed,float acum)
    {
        _transform = transform;
        _speed = speed;
        _acum = acum;
    }
    public void Movement()
    {
        _acum += Time.deltaTime;
        _transform.position += new Vector3(Mathf.Sin(_acum), 0, _speed * Time.deltaTime);

    }
}
