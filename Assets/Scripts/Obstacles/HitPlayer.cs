using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            {
                HitSounds.hitSound = true;
                Timer.remainingTime -= 5;
                Timer.flash = true;
                StartCoroutine(SlowWalk());
            }
        }
    }

    //create coroutine that will set PlayerMove.slowWalk to true for 5 seconds
    IEnumerator SlowWalk()
    {
        PlayerMove.slowWalk = true;
        yield return new WaitForSeconds(1.5f);
        PlayerMove.slowWalk = false;
    }
}
