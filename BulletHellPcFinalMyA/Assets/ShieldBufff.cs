using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBufff : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null && !player.TripleShoot)
        {
            player.Shield = true;
            gameObject.SetActive(false);
        }
    }

}
