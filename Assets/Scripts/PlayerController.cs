using UnityEngine;

public class PlayerController : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float moveSpeed = 3.0f;

    private Rigidbody2D rb;
    private Animator playerAnim;

    private float angle = 0f;
=======
    [SerializeField] private float addForce = 5.0f;
    [SerializeField] private float moveSpeed = 3.0f;

    private Rigidbody2D rb;

    private Animator playerAnim;
>>>>>>> 210de02f7ae364dddcaebd41b04eb8746ba8e826
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }
<<<<<<< HEAD

    private void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        //PlayerAnimation();
        Rotation();
    }
    private void PlayerAnimation()
    {
        //y이동값에 따라 위, 아래 애니메이션 달라지게 설정
        playerAnim.SetFloat("Velocity.y", rb.velocity.y);
    }

    //캐릭터 보는 방향 함수
    private void Rotation()
    {
        float velocityY = rb.velocity.y;
        float target = 0f;

        //위로 이동 시 45도, 아래로  -45도
        if (velocityY > 0.01f)
        {
            target = 45f;
        }
        else if (velocityY < -0.01f)
        {
            target = -45f;
        }

        //부드럽게 회전
        angle = Mathf.Lerp(angle, target, Time.deltaTime * 5f);

        //Clamp -> 각도 제한(-45~45)
        angle = Mathf.Clamp(angle, -45f, 45f);

        //회전 적용
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
=======
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
>>>>>>> 210de02f7ae364dddcaebd41b04eb8746ba8e826
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
<<<<<<< HEAD
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
=======
            rb.velocity = new Vector2(rb.velocity.x, addForce);
        }

        RotatePlayer();
    }

    //플레이어 보는 방향 함수
    private void RotatePlayer()
    {
        //5f(점프높이)만큼 각도정하기, 아래로는 최대 -90, 위로는 최대45
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
        if (other.CompareTag("Pipe") || other.CompareTag("Ground"))
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
}
