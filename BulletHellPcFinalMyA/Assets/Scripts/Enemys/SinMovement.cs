using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMovement : MonoBehaviour
{
    float SincenterX;
    public float amplitud;
    public float frecuencia=0.5f;
    private void Start()
    {
        SincenterX = transform.position.x;
    }
    private void Update()
    {
        Vector3 pos = transform.position;
        float sin = Mathf.Sin(pos.z * frecuencia) * amplitud;
        pos.x = SincenterX + sin;
        transform.position = pos;
    }
}
