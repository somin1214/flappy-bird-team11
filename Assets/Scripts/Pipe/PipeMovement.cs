using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    //변경 처리 가능한 기본 이동 속도
    //유니티에서 플레이어와 확인 필요

    //실제 적용될 속도 (추후 점수에 따라 변화하기 위함)
    public float Speed
    {
        get { return Speed; }
        set { Speed = moveSpeed; } //score 활용법 고민 필요
    }
    private ScoreZone scoring;
    private int score;

    private Vector2 initSpawnPosition;
    [SerializeField] float deSpawnX = -10.0f;

    private void Awake()
    {
        //속도 처리 변수를 위해 점수를 받아옴
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
