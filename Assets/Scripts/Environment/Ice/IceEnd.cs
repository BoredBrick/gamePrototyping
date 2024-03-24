using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IceEffect.Instance.DeactivateIce();
        }
    }
}
