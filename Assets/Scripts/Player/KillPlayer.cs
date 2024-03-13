using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            GameOver gameOverScreen = GameObject.Find("Scripts").GetComponent<GameOver>();
            gameOverScreen.Display(Points.score);
        }
    }
}
