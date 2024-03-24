using UnityEngine;

public class WindEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WindEffect.Instance.StopWind();
        }
    }
}
