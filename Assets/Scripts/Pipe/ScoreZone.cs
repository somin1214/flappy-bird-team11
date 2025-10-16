using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public int score;   //���� (����� ������ ��)

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.Die();

            GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
            if (pipes != null)
            {
                foreach (GameObject pipe in pipes)
                {
                    pipe.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //�ν��� �Ǵµ� ���� ī��Ʈ�� �� ��
            //GameManager ȣ���ؼ� ó���ؾ� �� ��
        }
    }
}
