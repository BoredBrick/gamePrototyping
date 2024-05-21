using Assets.Scripts;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static float moveSpeed;
    public static float jumpForce;
    public Animator animator;
    public Transform modelToRotate;
    public static bool slowWalk = false;
    bool releasedJump = true;

    private void Awake()
    {
        moveSpeed = Constants.defaultMoveSpeed;
        jumpForce = Constants.defaultJumpForce;
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;
        movement.Normalize();

        float currentMoveSpeed;

        currentMoveSpeed = CalcCurrentMoveSpeed();
        if (movement == Vector3.zero)
        {
            transform.Translate(movement);
            movement = new(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }

        movement.z = 1;

         transform.Translate(currentMoveSpeed * Time.deltaTime * movement);
        CheckBoundary();
        RotateModel(movement);
    }

    private float CalcCurrentMoveSpeed()
    {
        float currentMoveSpeed;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetAxis("RightTrigger") > 0)
        {
            animator.SetBool("isWalking", true);
            Timer.doubleSpeed = true;
            currentMoveSpeed = moveSpeed * 0.5f;
            float maxFOV = 82;
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, maxFOV, 5f * Time.deltaTime);

        }
        else if (slowWalk)
        {
            currentMoveSpeed = moveSpeed * 0.5f;
            animator.SetBool("isWalking", true);

        }
        else
        {
            animator.SetBool("isWalking", false);
            Timer.doubleSpeed = false;
            currentMoveSpeed = moveSpeed;
            float maxFOV = 97;
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, maxFOV, 3.5f * Time.deltaTime);

        }

        return currentMoveSpeed;
    }

    private void RotateModel(Vector3 movement)
    {
        if (movement.z > 0 && movement.y == 0 && movement.x == 0) // Check if movement is forward
        {
            Quaternion targetRotation = Quaternion.LookRotation(-movement, Vector3.up);
            modelToRotate.rotation = Quaternion.Lerp(modelToRotate.rotation, targetRotation, Time.deltaTime * 30.0f);
        }
        else if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(-movement, Vector3.up);
            modelToRotate.rotation = Quaternion.Lerp(modelToRotate.rotation, targetRotation, Time.deltaTime * 12.0f); // Smooth rotation
        }
    }

    private void CheckBoundary()
    {
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
        if ((Input.GetButton("Jump") || Input.GetKey(KeyCode.Space)))
        {
            if (gameObject.transform.position.y <= 0.96 && gameObject.transform.position.y >= 0.8 && releasedJump)
            {
                releasedJump = false;
                animator.SetTrigger("jump");
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            }
        } else
        {
            releasedJump = true;
        }
    }
}
