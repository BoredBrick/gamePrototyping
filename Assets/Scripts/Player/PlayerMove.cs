using Assets.Scripts;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static float moveSpeed;
    public static float jumpForce;
    public Animator animator;
    public Transform modelToRotate; 

    private void Awake()
    {
        moveSpeed = Constants.defaultMoveSpeed;
        jumpForce = Constants.defaultJumpForce;
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Vector3 movement = new(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //Vector3 movement = Vector3.zero;
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

        movement.Normalize();

        float currentMoveSpeed;

        currentMoveSpeed = CalcCurrentMoveSpeed();

        transform.Translate(currentMoveSpeed * Time.deltaTime * movement);

        CheckBoundary();
        RotateModel(movement);
    }

    private static float CalcCurrentMoveSpeed()
    {
        float currentMoveSpeed;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetAxis("RightTrigger") > 0)
        {
            Timer.doubleSpeed = true;
            currentMoveSpeed = moveSpeed * 0.5f;
        }
        else
        {
            Timer.doubleSpeed = false;
            currentMoveSpeed = moveSpeed;
        }

        return currentMoveSpeed;
    }

    private void RotateModel(Vector3 movement)
    {
        if (movement != Vector3.zero && modelToRotate != null)
        {
            Quaternion targetRotation = Quaternion.LookRotation(-movement, Vector3.up);
            modelToRotate.rotation = Quaternion.Lerp(modelToRotate.rotation, targetRotation, Time.deltaTime * 10.0f);
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
            if (gameObject.transform.position.y <= 1)
            {
                animator.SetTrigger("jump");
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            }
        }
    }
}
