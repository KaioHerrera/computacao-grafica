using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 6f;
    public float lateralSpeed = 4f;
    public float slowMultiplier = 0.5f;
    public float slowDuration = 1.5f;

    private Rigidbody rb;
    private float lateralInput;
    private float verticalInput;
    private float currentForwardSpeed;
    private bool isSlowed = false;
    private float slowTimer = 0f;

    public Animator animator;
    public AudioSource audioSource;
    public AudioClip collectSfx;
    public AudioClip hitSfx;

    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentForwardSpeed = forwardSpeed;
        gameManager = GameManager.Instance;
    }

    void Update()
    {
        lateralInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (animator)
            animator.SetFloat("Speed", Mathf.Abs(verticalInput * currentForwardSpeed));

        if (isSlowed)
        {
            slowTimer -= Time.deltaTime;
            if (slowTimer <= 0f)
            {
                isSlowed = false;
                currentForwardSpeed = forwardSpeed;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        Vector3 cameraRight = Camera.main.transform.right;
        cameraRight.y = 0f;
        cameraRight.Normalize();

        Vector3 forwardMove = cameraForward * verticalInput * currentForwardSpeed * Time.fixedDeltaTime;
        Vector3 lateralMove = cameraRight * lateralInput * lateralSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + forwardMove + lateralMove);

        Vector3 moveDirection = forwardMove + lateralMove;
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, Time.fixedDeltaTime * 10f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Seed"))
        {
            var seed = other.GetComponent<Seed>();
            if (seed != null)
            {
                seed.Collect();
                if (audioSource && collectSfx) audioSource.PlayOneShot(collectSfx);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            HitObstacle();
        }
    }

    public void HitObstacle()
    {
        if (audioSource && hitSfx) audioSource.PlayOneShot(hitSfx);
        isSlowed = true;
        slowTimer = slowDuration;
        currentForwardSpeed = forwardSpeed * slowMultiplier;
        if (animator) animator.SetTrigger("Hit");
        if (gameManager) gameManager.OnPlayerHit();
    }
}
