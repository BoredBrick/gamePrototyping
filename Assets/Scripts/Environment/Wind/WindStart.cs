using UnityEngine;

public class WindStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WindEffect.Instance.StartWind();
        }
    }
}