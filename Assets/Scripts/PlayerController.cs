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
        //y�̵����� ���� ��, �Ʒ� �ִϸ��̼� �޶����� ����
        playerAnim.SetFloat("Velocity.y", rb.velocity.y);
    }

    //ĳ���� ���� ���� �Լ�
    private void Rotation()
    {
        float velocityY = rb.velocity.y;
        float target = 0f;

        //���� �̵� �� 45��, �Ʒ���  -45��
        if (velocityY > 0.01f)
        {
            target = 45f;
        }
        else if (velocityY < -0.01f)
        {
            target = -45f;
        }

        //�ε巴�� ȸ��
        angle = Mathf.Lerp(angle, target, Time.deltaTime * 5f);

        //Clamp -> ���� ����(-45~45)
        angle = Mathf.Clamp(angle, -45f, 45f);

        //ȸ�� ����
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
