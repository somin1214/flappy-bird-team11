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
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
