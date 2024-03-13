using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static float moveSpeed = Constants.defaultMoveSpeed;
    public float sideSpeed = 4;
    public static float jumpForce = Constants.defaultJumpForce;
    public Animator animator;
    private BoxCollider colliderBox;
    private bool jumpCooldownFinished = true;

    private void Awake()
    {
        moveSpeed = Constants.defaultMoveSpeed;
        jumpForce = Constants.defaultJumpForce;
        animator = GetComponentInChildren<Animator>();
        colliderBox = gameObject.GetComponent<BoxCollider>();
    }
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (gameObject.transform.position.x > LevelBoundary.leftBoundary)
            {
                transform.Translate(moveSpeed * Time.deltaTime * Vector3.left);
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (gameObject.transform.position.x < LevelBoundary.rightBoundary)
            {
                transform.Translate(moveSpeed * Time.deltaTime * -1f * Vector3.left);
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (gameObject.transform.position.y <= 1.26 && jumpCooldownFinished)
            {
                jumpCooldownFinished = false;
                animator.SetTrigger("jump");
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                colliderBox.center = new Vector3(colliderBox.center.x, 0.44f, colliderBox.center.z);
                colliderBox.size = new Vector3(colliderBox.size.x, 0.7f, colliderBox.size.z);
                StartCoroutine(ChangeColliderAfterAnimation(0.52f));
                StartCoroutine(JumpCooldown());
            }
        }

    }

    IEnumerator ChangeColliderAfterAnimation(float waitTime)
    {
        while (waitTime >= 0.0f)
        {
            waitTime -= Time.deltaTime;
            yield return null;
        }
        colliderBox.center = new Vector3(colliderBox.center.x, 0.03274205f, colliderBox.center.z);
        colliderBox.size = new Vector3(colliderBox.size.x, 1.065485f, colliderBox.size.z);
    }

    IEnumerator JumpCooldown()
    {
        yield return new WaitForSecondsRealtime(1);
        jumpCooldownFinished = true;
    }
}
