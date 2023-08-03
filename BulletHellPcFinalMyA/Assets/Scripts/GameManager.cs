using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float XLine;
    public float XLineEnemy;
    public float ZLine;
    public float ZLineEnemy;
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
    public Vector3 transportPositionEnemy(Vector3 Actualposition)
    {
        if (Actualposition.z > ZLineEnemy / 2) Actualposition.z = -ZLineEnemy / 2;
        if (Actualposition.z < -ZLineEnemy / 2) Actualposition.z = ZLineEnemy / 2;
        if (Actualposition.x < -XLineEnemy / 2) Actualposition.x = XLineEnemy / 2;
        if (Actualposition.x > XLineEnemy / 2) Actualposition.x = -XLineEnemy / 2;
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

        Vector3 SupLeftRightEnemy = new Vector3(-XLineEnemy / 2, 0, ZLineEnemy / 2);
        Vector3 SupRightLeftEnemy = new Vector3(XLineEnemy / 2, 0, ZLineEnemy / 2);
        Vector3 InfLeftRightEnemy = new Vector3(-XLineEnemy / 2, 0, -ZLineEnemy / 2);
        Vector3 InfRightLeftEnemy = new Vector3(XLineEnemy / 2, 0, -ZLineEnemy / 2);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(SupLeftRightEnemy, SupRightLeftEnemy);
        Gizmos.DrawLine(SupRightLeftEnemy, InfRightLeftEnemy);
        Gizmos.DrawLine(InfRightLeftEnemy, InfLeftRightEnemy);
        Gizmos.DrawLine(InfLeftRightEnemy, SupLeftRightEnemy);
    }
}
