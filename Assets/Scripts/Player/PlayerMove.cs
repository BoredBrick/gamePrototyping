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
    AudioSource audioSource;
    public  AudioClip jump;
    public AudioClip land;
    public AudioClip[] walk;
    private float stepTimer;
    private float stepInterval;
    public CameraFade cameraFade;
    bool startedFade = false;

    private void Awake()
    {
        moveSpeed = Constants.defaultMoveSpeed;
        jumpForce = Constants.defaultJumpForce;
        animator = GetComponentInChildren<Animator>();
        audioSource = GameObject.FindGameObjectWithTag("Scripts").GetComponent<AudioSource>();

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

        if (movement != Vector3.zero)
        {
            stepTimer += Time.deltaTime;

            if (stepTimer >= stepInterval && gameObject.transform.position.y >= 0.8 && gameObject.transform.position.y <=  0.96)
            {
                audioSource.PlayOneShot(walk[Random.Range(0,walk.Length)]);
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f; // Reset the timer when the player stops moving
        }

        if (gameObject.transform.position.y <= 0 && !startedFade)
        {
            startedFade = true;
            cameraFade.FadeIn();
        }
        
    }

    private float CalcCurrentMoveSpeed()
    {
        float currentMoveSpeed;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetAxis("RightTrigger") > 0)
        {
            animator.SetBool("isWalking", true);
            Timer.doubleSpeed = true;
            currentMoveSpeed = moveSpeed * 0.5f;
            stepInterval = 0.35f; // Example interval adjustment for running
            float maxFOV = 82;
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, maxFOV, 5f * Time.deltaTime);
        }
        else if (slowWalk)
        {
            currentMoveSpeed = moveSpeed * 0.5f;
            animator.SetBool("isWalking", true);
            stepInterval = 0.35f; // Example interval adjustment for walking
            float maxFOV = 82;
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, maxFOV, 5f * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isWalking", false);
            Timer.doubleSpeed = false;
            currentMoveSpeed = moveSpeed;
            stepInterval = 0.25f; // Example interval adjustment for normal speed
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
            if (gameObject.transform.position.y <= 0.98 && gameObject.transform.position.y >= 0.8)
            {
                stepTimer = 0f;
                audioSource.PlayOneShot(jump);
                animator.Play("jump");
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            }
        } 
    }
}
