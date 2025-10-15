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

    private void PlayerAnimation()
    {
        //y�� �����ӿ� ���� �ִϸ��̼� �޶����� ����
        playerAnim.SetFloat("velocityY", rb.velocity.y);
    }
}
