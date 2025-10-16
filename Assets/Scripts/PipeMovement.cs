using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    //���� ó�� ������ �⺻ �̵� �ӵ�
    //����Ƽ���� �÷��̾�� Ȯ�� �ʿ�

    private float Speed;
    //���� ����� �ӵ�

    public int Score;   //���� (����� ������ ��)

    //������ �ӵ� ���� ����/�Լ� �ʿ�

    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //�� �κ��� ����Ƽ���� �������� CompareTag�� ����
        if (col.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Score++;
        }
    }
}
