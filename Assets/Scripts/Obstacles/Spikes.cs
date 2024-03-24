using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Transform objectToMove; 
    public float moveDistance = 2f; 
    public float moveSpeed = 1f; 
    public float waitTime = 1f; 

    private Vector3 initialPosition;
    private Vector3 targetPosition;

    void Start()
    {
        initialPosition = objectToMove.position;
        targetPosition = initialPosition + Vector3.down * moveDistance; 
        StartCoroutine(SpikeSequence());
    }

    IEnumerator SpikeSequence()
    {
        while (true)
        {
            yield return StartCoroutine(MoveObject(objectToMove, targetPosition));
            yield return new WaitForSeconds(waitTime);

            yield return StartCoroutine(MoveObject(objectToMove, initialPosition));
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator MoveObject(Transform obj, Vector3 target)
    {
        float distance = Vector3.Distance(obj.position, target);
        while (distance > 0.01f)
        {
            obj.position = Vector3.MoveTowards(obj.position, target, moveSpeed * Time.deltaTime);
            distance = Vector3.Distance(obj.position, target);
            yield return null;
        }
    }
}
