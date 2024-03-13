using System.Collections.Generic;
using UnityEngine;

public class GeneratePickup : MonoBehaviour
{
    public List<GameObject> pickUps;

    private void Awake()
    {
        var value = Random.value;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        if (value <= 0.5)
        {
            Instantiate(pickUps[0], gameObject.transform.position, Quaternion.identity, gameObject.transform);
        }
        else if (value <= 0.9)
        {
            Instantiate(pickUps[1], gameObject.transform.position, Quaternion.identity, gameObject.transform);
        }
        else
        {
            Instantiate(pickUps[2], gameObject.transform.position, Quaternion.identity, gameObject.transform);
        }
    }
}
