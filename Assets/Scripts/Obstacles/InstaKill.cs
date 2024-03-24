using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerLives.lives = 0;
        }
    }
}
