using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSin : IAdvance
{
    Transform _transform;
    float _speed;
    float _acum;
    public MovementSin(Transform transform, float speed)
    {
        _transform = transform;
        _speed = speed;

    }
    public void Movement()
    {

        //_acum += Time.deltaTime;
        //_transform.position += new Vector3(Mathf.Sin(_acum), 0, _speed * Time.deltaTime);
        _transform.position += _transform.forward * _speed * Time.deltaTime;
        //_transform.position = _transform + _transform.right * Mathf.Sin(Time.time * frecuency) * magnitude;
    }
}
