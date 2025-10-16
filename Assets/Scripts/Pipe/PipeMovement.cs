using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    //변경 처리 가능한 기본 이동 속도
    //유니티에서 플레이어와 확인 필요

    //실제 적용될 속도
    public float Speed
    {
        get { return Speed; }
        set { Speed = moveSpeed; } //score Ȱ��� ���� �ʿ�
    }
    private ScoreZone scoring;
    private int score;
    private int speedUpCount;

    private Vector2 initSpawnPosition;
    [SerializeField] float deSpawnX = -10.0f;

    private void Awake()
    {
        //속도 처리 변수를 위해 점수를 받아옴
        scoring = GetComponent<ScoreZone>();
        score = scoring.score;
        speedUpCount = score / 10;
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
