using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public int score;   // 현재 점수

    [SerializeField] private GameObject gameManager;
    private GameManager gmScript;

    private void Awake()
    {
        if (gameManager != null)
            gmScript = gameManager.GetComponent<GameManager>();
    }
    private void Update()
    {
        if (gmScript != null)
            score = gmScript.GetScore();
    }

    //ScoreZone 코드 수정
    // private void OnTriggerEnter2D(Collider2D col)
    // {
    //     if (col.CompareTag("Player"))
    //     {
    //         if (gmScript != null)
    //             gmScript.AddScore();
    //     }
    // }
}