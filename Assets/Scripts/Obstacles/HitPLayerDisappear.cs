using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayerDissapear : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerLives.RemoveLife();
            Destroy(gameObject);
        }
    }
}
