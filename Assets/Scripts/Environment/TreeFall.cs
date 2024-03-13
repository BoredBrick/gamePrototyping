using UnityEngine;

public class TreeFall : MonoBehaviour
{
    public GameObject Tree;
    private bool falling = false;
    public bool rightSideFall;
    public bool randomFall;
    private Quaternion finalRotationFallLeft = Quaternion.Euler(-94.31f, -85.798f, 170.879f);
    private Quaternion finalRotationFallRight = Quaternion.Euler(88.486f, 58.308f, -26.807f);
    private Quaternion finalRotation;
    private readonly float rotationSpeed = 1.5f;
    private void OnTriggerEnter(Collider obstacle)
    {
        if (obstacle.CompareTag("Player"))
        {
            if (Random.value <= 0.75)
            {
                falling = true;
                if (randomFall)
                {
                    finalRotation = Random.value <= 0.5 ? finalRotationFallLeft : finalRotationFallRight;
                }
                else
                {
                    finalRotation = rightSideFall ? finalRotationFallRight : finalRotationFallLeft;
                }
            }
        }
    }

    private void Update()
    {
        if (falling)
        {
            Tree.transform.rotation = Quaternion.Slerp(Tree.transform.rotation, finalRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
