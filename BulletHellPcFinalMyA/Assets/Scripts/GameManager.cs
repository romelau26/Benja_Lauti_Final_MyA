using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float XLine;
    public float ZLine;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public Vector3 transportPosition(Vector3 Actualposition)
    {
        if (Actualposition.z > ZLine / 2) Actualposition.z = -ZLine / 2;
        if (Actualposition.z < -ZLine / 2) Actualposition.z = ZLine / 2;
        if (Actualposition.x < -XLine / 2) Actualposition.x = XLine / 2;
        if (Actualposition.x > XLine / 2) Actualposition.x = -XLine / 2;
        return Actualposition;
    }
    private void OnDrawGizmos()
    {
        Vector3 SupLeftRight = new Vector3(-XLine / 2, 0, ZLine / 2);
        Vector3 SupRightLeft = new Vector3(XLine / 2, 0, ZLine / 2);
        Vector3 InfLeftRight = new Vector3(-XLine / 2, 0, -ZLine / 2);
        Vector3 InfRightLeft = new Vector3(XLine / 2, 0, -ZLine / 2);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(SupLeftRight, SupRightLeft);
        Gizmos.DrawLine(SupRightLeft, InfRightLeft);
        Gizmos.DrawLine(InfRightLeft, InfLeftRight);
        Gizmos.DrawLine(InfLeftRight, SupLeftRight);
    }
}
