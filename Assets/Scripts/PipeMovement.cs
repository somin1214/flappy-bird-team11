using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    //�̵� �ӵ�. �ٰ����� �÷��̾�� �����ϴ� ���� �ʿ��� ��...
    
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    /****************************************
    ������ �κ��� �Ϲ� �ݶ��̴�, ����Ʈ ȹ��(����) �κ��� isTrigger�� �����صξ�����,
    �÷��̾� �ڵ� �󿡼� �±׷� �����Ͻ� ���� �ּ� ó���صӴϴ�.

    
    //private void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
    //    {
    //        //�÷��̾� ��� ó�� �� ���� ���� ȣ��
    //    }
    //}
    //
    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.CompareTag("Player"))
    //    {
    //        //���� ����
    //        //���ӸŴ��� �Լ� ȣ�� or �̰����� ī��Ʈ�� �� ���ӸŴ����� ����
    //    }
    //}
     ****************************************/
}
