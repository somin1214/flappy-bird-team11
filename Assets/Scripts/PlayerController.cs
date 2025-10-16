using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float moveSpeed = 3.0f;

    private Rigidbody2D rb;
    private Animator playerAnim;
    private float angle = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        RotatePlayer();
        UpdateAnimation();
    }

    private void RotatePlayer()
    {
        // y속도에 따라 회전 (위로 올라갈 때 45도, 아래로 내려갈 때 -45도)
        float velocityY = rb.velocity.y;
        float targetAngle = 0f;

        if (velocityY > 0.01f)
            targetAngle = 45f;
        else if (velocityY < -0.01f)
            targetAngle = -45f;

        // 부드럽게 회전
        angle = Mathf.Lerp(angle, targetAngle, Time.deltaTime * 5f);
        angle = Mathf.Clamp(angle, -45f, 45f);

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void UpdateAnimation()
    {
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

    private void Die()
    {
        rb.velocity = Vector2.zero;
        Destroy(gameObject);
    }
}
