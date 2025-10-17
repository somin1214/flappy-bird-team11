using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float jumpForce = 7.0f;       // 점프 힘
    [SerializeField] private float moveSpeed = 2.0f;       // 앞으로 이동 속도
    [SerializeField] private float rotationSpeed = 5.0f;   // 회전 속도
    [SerializeField] private float maxRotation = 45f;      // 최대 회전 각도

    private Rigidbody2D rb;
    private Animator playerAnim;
    private float angle = 0f;

    private bool flapRequested = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 1f;
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // on mouse click flap
        if (Input.GetMouseButtonDown(0))
        {
            flapRequested = true;
        }

        // 플레이어 회전 처리
        RotatePlayer();

        // Animator 업데이트
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        // on flap apply jump force
        if (flapRequested)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            flapRequested = false;
        }

        // keep moving forward
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    // 게임 시작 시 초기화
    public void StartPlay()
    {
        gameObject.SetActive(true);
        rb.velocity = Vector2.zero;
        rb.gravityScale = 1f;
        flapRequested = false;
        angle = 0f;
        transform.position = new Vector3(-5f, 0f, 0f); // 시작 위치
        transform.rotation = Quaternion.identity;
    }

    private void RotatePlayer()
    {
        // y속도에 따라 회전 (위로 올라갈 때 45도, 아래로 내려갈 때 -45도)
        float velocityY = rb.velocity.y;
        float targetAngle = 0f;

        if (velocityY > 0.01f)
            targetAngle = maxRotation;
        else if (velocityY < -0.01f)
            targetAngle = -maxRotation;

        // 부드럽게 회전
        angle = Mathf.Lerp(angle, targetAngle, Time.deltaTime * rotationSpeed);
        angle = Mathf.Clamp(angle, -maxRotation, maxRotation);

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void UpdateAnimation()
    {
        // Animator에 y속도 전달
        if (playerAnim != null)
            playerAnim.SetFloat("velocityY", rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 장애물 또는 바닥과 충돌 시 사망 처리
        if (other.CompareTag("Pipe") || other.CompareTag("Ground"))
        {
            Die();
        }
    }

    public void Die()
    {
        rb.velocity = Vector2.zero;
        GameManager.instance.GameOver();
        gameObject.SetActive(false); // Deactivate instead of destroying
    }
}
