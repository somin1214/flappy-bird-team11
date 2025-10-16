using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float speedUp = 0.01f;
    //���� ó�� ������ �⺻ �̵� �ӵ�
    //����Ƽ���� �÷��̾�� Ȯ�� �ʿ�

    //���� ����� �ӵ�
    public float Speed
    {
        get { return Speed; }
        set { Speed = moveSpeed * 1+(speedUpCount * speedUp); }
        //10�� �� moveSpeed * 1.01f ��ŭ ����
    }
    private ScoreZone scoring;
    private int score;
    private int speedUpCount;

    private Vector2 initSpawnPosition;
    [SerializeField] float deSpawnX = -10.0f;

    private void Awake()
    {
        //�ӵ� ó�� ������ ���� ������ �޾ƿ�
        scoring = GetComponent<ScoreZone>();
        score = scoring.score;
        speedUpCount = score/10;
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
