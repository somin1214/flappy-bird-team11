using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    //변경 처리 가능한 기본 이동 속도
    //유니티에서 플레이어와 확인 필요

    private float Speed;
    //실제 적용될 속도

    public int Score;   //점수 (통과한 파이프 수)

    //점수별 속도 조절 변수/함수 필요

    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //이 부분은 유니티에서 오류나면 CompareTag로 변경
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
