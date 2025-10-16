using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public int score;   //점수 (통과한 파이프 수)

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //인식은 되는데 점수 카운트가 안 됨
            //GameManager 호출해서 처리해야 할 듯
        }
    }
}
