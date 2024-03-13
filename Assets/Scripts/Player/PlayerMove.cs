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
        // Calculate movement direction based on input
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movement += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movement += Vector3.right;
        }

        // Normalize the movement vector to ensure consistent speed diagonally
        movement.Normalize();

        // Adjust movement speed if Shift key is pressed
        float currentMoveSpeed = Input.GetKey(KeyCode.LeftShift) ? moveSpeed * 0.5f : moveSpeed;

        // Translate the player's position based on movement direction and speed
        transform.Translate(currentMoveSpeed * Time.deltaTime * movement);

        if (gameObject.transform.position.x > LevelBoundary.rightBoundary)
        {
            transform.position = new Vector3(LevelBoundary.rightBoundary, transform.position.y, transform.position.z);
        }
        else if (gameObject.transform.position.x < LevelBoundary.leftBoundary)
        {
            transform.position = new Vector3(LevelBoundary.leftBoundary, transform.position.y, transform.position.z);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
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
