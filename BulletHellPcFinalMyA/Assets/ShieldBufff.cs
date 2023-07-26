using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBufff : MonoBehaviour
{
    public SpawnBuffs MgSpawn;
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null && !player.TripleShoot)
        {
            MgSpawn.CurrentBuff-=2;
            player.Shield = true;
            gameObject.SetActive(false);
        }
    }

}
