using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float despawnX = -10f;
    //변경 처리 가능한 기본 이동 속도
    //유니티에서 플레이어와 확인 필요

    //���� ����� �ӵ�
    public float Speed
    {
        get { return moveSpeed; }
        set { moveSpeed = value * (1f + (speedUpCount * 0.01f)); }
        //10일 때 moveSpeed * 1.01f 만큼 증가
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
