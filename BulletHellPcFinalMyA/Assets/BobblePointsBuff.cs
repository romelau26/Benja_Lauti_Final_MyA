using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobblePointsBuff : MonoBehaviour
{
    public SpawnBuffs MgSpawn;
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null && player.DoblePoints==false)
        {
            MgSpawn.CurrentBuff -= 2;
            player.DoblePoints = true;
            gameObject.SetActive(false);
        }
    }
}
