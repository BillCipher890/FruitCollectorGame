using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoxSender : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GlobalEventManager.SendOnDeath();
        }
    }
}
