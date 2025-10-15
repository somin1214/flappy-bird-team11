using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float addForce = 5.0f;
    [SerializeField] private float moveSpeed = 3.0f;

    private Rigidbody2D rb;

    private Animator playerAnim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(rb.velocity.x, addForce);
        }

        RotatePlayer();
    }

    //캐릭터가 바라보는 방향 함수
    private void RotatePlayer()
    {
        //5f(점프속도), 아래로 -90도, 위로 45도만큼 설정
        float angle = Mathf.Clamp(rb.velocity.y * 5f, -90f, 45f);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("Score"))
        //{
        //    AddScore();
        //}

        //파이프 or 위,아래 땅에 닿으면 죽음
        if (other.CompareTag("Pipe") && other.CompareTag("Ground"))
        {
            Die();
        }

        PlayerAnimation();
    }

    private void Die()
    {
        //죽으면 속도0 설정
        rb.velocity = Vector2.zero;

        Destroy(gameObject);
    }

    private void PlayerAnimation()
    {
        //y축 움짐임에 따라 애니메이션 달라지게 설정
        playerAnim.SetFloat("Velocity.y", rb.velocity.y);
    }
}
