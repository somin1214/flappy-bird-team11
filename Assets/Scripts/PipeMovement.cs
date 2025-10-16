using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    //이동 속도. 다가오는 플레이어와 조절하는 과정 필요할 듯...
    
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    /****************************************
    파이프 부분을 일반 콜라이더, 포인트 획득(사이) 부분을 isTrigger로 구분해두었지만,
    플레이어 코드 상에서 태그로 구별하신 듯해 주석 처리해둡니다.

    
    //private void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
    //    {
    //        //플레이어 사망 처리 및 게임 종료 호출
    //    }
    //}
    //
    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.CompareTag("Player"))
    //    {
    //        //점수 증가
    //        //게임매니저 함수 호출 or 이곳에서 카운트한 뒤 게임매니저로 전송
    //    }
    //}
     ****************************************/
}
