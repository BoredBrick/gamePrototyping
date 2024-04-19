using UnityEngine;

public class LifePotion : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLives.AddLife();
            gameObject.SetActive(false);
        }
    }
}
