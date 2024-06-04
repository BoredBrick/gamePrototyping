// GroundSlowDown.cs
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMove playerMove = other.GetComponent<PlayerMove>();
            if (playerMove != null)
            {
                PlayerMove.slowWalk = true;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMove playerMove = other.GetComponent<PlayerMove>();
            if (playerMove != null)
            {
                PlayerMove.slowWalk = false;
            }
        }
    }
}
