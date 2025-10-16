using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float destroyX = -10f;

    //변경 처리 가능한 기본 이동 속도
    //유니티에서 플레이어와 확인 필요
    private ScoreZone scoring;
    private int score;
    private int speedUpCount;

    private Vector2 initSpawnPosition;
    //실제 적용될 속도
    public float Speed
    {
        get { return moveSpeed; }
        set { moveSpeed = value * (1f+(speedUpCount * 0.01f)); }
        //10일 때 moveSpeed * 1.01f 만큼 증가
    }

    private void Awake()
    {
        //속도 처리 변수를 위해 점수를 받아옴
        scoring = GetComponent<ScoreZone>();
        if(scoring != null)
        {
            score = scoring.score;
            speedUpCount = score / 10;
        }
    }
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < destroyX)
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
