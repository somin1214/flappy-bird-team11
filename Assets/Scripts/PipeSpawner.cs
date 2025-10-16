using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    private int pipePoolSize = 10;
    private GameObject[] pipes;

    [Header("프리팹")]
    public GameObject greenPipePrefab;
    public GameObject redPipePrefab;


    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    //시작할 때 스크린 밖에 배치

    private float timeSinceLastSpawned;
    public float spawnRate = 4f;

    public float columnMin = 0.6f;
    public float columnMax = 6.6f;
    private float spawnXPosition = 10f;
    private int currentPipe = 0;


    void Start()
    {
        pipes = new GameObject[pipePoolSize];

        for (int i = 0; i < pipePoolSize; i++)
        {
            if (i == 9)    //n0번째 빨간색
            {
                pipes[i] = Instantiate(redPipePrefab, objectPoolPosition, Quaternion.identity);
            }
            else
            {
                pipes[i] = Instantiate(greenPipePrefab, objectPoolPosition, Quaternion.identity);
            }
        }
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            pipes[currentPipe].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentPipe++;

            if (currentPipe >= pipePoolSize)
            {
                currentPipe = 0;
            }
        }
    }
}
