using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMovement : MonoBehaviour
{
    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        float sin = Mathf.Sin(pos.z);
        pos.x = sin;
        transform.position = pos;
    }
}
