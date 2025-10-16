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

    //�÷��̾� ���� ���� �Լ�
    private void RotatePlayer()
    {
        //5f(��������)��ŭ �������ϱ�, �Ʒ��δ� �ִ� -90, ���δ� �ִ�45
        float angle = Mathf.Clamp(rb.velocity.y * 5f, -90f, 45f);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("Score"))
        //{
        //    AddScore();
        //}

        //������ or ��,�Ʒ� ���� ������ ����
        if (other.CompareTag("Pipe") || other.CompareTag("Ground"))
        {
            Die();
        }

        PlayerAnimation();
    }

    private void Die()
    {
        //������ �ӵ�0 ����
        rb.velocity = Vector2.zero;

        Destroy(gameObject);
    }
}
