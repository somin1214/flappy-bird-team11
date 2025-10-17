using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("설정")]
    [SerializeField] private PipeMovement pipePrefab;
    [SerializeField] private int pipePoolSize = 5;
    [SerializeField] private float heightMin = 2.0f;
    [SerializeField] private float heightMax = 5.0f;
    [SerializeField] private float spawnInterval = 1.7f;


    private float spawnX = 10.0f;
    private float spawnY;


    private List<PipeMovement> pipes = new List<PipeMovement>();

    void Start()
    {
        Debug.Log("🔥 PipeSpawner.Start() called!");
        SetupPipes();
    }

    public void StartSpawning()
    {
        Debug.Log("🚀 StartSpawning() called!");
        StartCoroutine(AutoSpawnCo());
    }

    //시작 지점 개수만큼 프리팹 생성
    private void SetupPipes()
    {
        for (int i = 0; i < pipePoolSize; i++)
        {
            var pipe = Instantiate(pipePrefab, transform);
            pipe.gameObject.SetActive(false);
            pipes.Add(pipe);
        }
    }
    //스폰 반복
    private IEnumerator AutoSpawnCo()
    {
        Debug.Log("🚀 AutoSpawnCo started!");
        while (true)
        {
            SpawnOffset();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    //스폰 위치 지정
    private void SpawnOffset()
    {
        spawnY = Random.Range(heightMin, heightMax);
        Debug.Log($"🌈 Spawning pipe at Y = {spawnY}");
        Vector2 pos = new Vector2(spawnX, spawnY);
        SpawnPipe(pos);
    }
    //스폰
    public void SpawnPipe(Vector2 spawnPosition)
    {
        PipeMovement pipe = GetFromPipe();
        pipe.transform.position = spawnPosition;

        pipe.gameObject.SetActive(true);

    }
    //파이프를 가져옴
    private PipeMovement GetFromPipe()
    {
        for (int i = 0; i < pipes.Count; i++)
        {
            var p = pipes[i];

            if (p != null && !p.gameObject.activeInHierarchy)
            {
                return p;
            }
        }
        //비활성화된 프리팹이 없으면 추가 생성
        var newPipe = Instantiate(pipePrefab, transform);
        newPipe.gameObject.SetActive(false);
        pipes.Add(newPipe);
        return newPipe;
    }
}
