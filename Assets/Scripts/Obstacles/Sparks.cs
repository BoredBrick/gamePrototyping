using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", 1f);
    }

    // Update is called once per frame
    void Die()
    {
        Destroy(gameObject);
    }
}