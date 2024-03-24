using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IceEffect.Instance.ActivateIce();
            Debug.Log("Ice activated");
        }
    }
}
