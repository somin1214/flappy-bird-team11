using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    //���� ó�� ������ �⺻ �̵� �ӵ�
    //����Ƽ���� �÷��̾�� Ȯ�� �ʿ�

    //���� ����� �ӵ� (���� ������ ���� ��ȭ�ϱ� ����)
    public float Speed
    {
        get { return Speed; }
        set { Speed = moveSpeed; } //score Ȱ��� ��� �ʿ�
    }
    private ScoreZone scoring;
    private int score;

    private Vector2 initSpawnPosition;
    [SerializeField] float deSpawnX = -10.0f;

    private void Awake()
    {
        //�ӵ� ó�� ������ ���� ������ �޾ƿ�
        scoring = GetComponent<ScoreZone>();
        score = scoring.score;
    }
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < deSpawnX)
        {
            gameObject.SetActive(false);
        }
    }
    public void Init(Vector2 spawnPosition)
    {
        initSpawnPosition = spawnPosition;
        transform.position = initSpawnPosition;
    }
}
