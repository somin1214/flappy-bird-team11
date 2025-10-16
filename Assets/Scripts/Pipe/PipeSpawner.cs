using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("����")]
    [SerializeField] private PipeMovement pipePrefab;
    [SerializeField] private int pipePoolSize = 5;
    [SerializeField] private float columnMin = 2.0f;
    [SerializeField] private float columnMax = 5.0f;
    [SerializeField] private float spawnInterval = 1.7f;


    private float spawnX = 10.0f;
    private float spawnY;


    private List<PipeMovement> pipes = new List<PipeMovement>();

    void Start()
    {
        SetupPipes();
        StartCoroutine(AutoSpawnCo());
    }

    //���� ���� ������ŭ ������ ����
    private void SetupPipes()
    {
        for (int i = 0; i < pipePoolSize; i++)
        {
            var pipe = Instantiate(pipePrefab, transform);
            pipe.gameObject.SetActive(false);
            pipes.Add(pipe);
            //������...
        }
    }
    //���� �ݺ�
    private IEnumerator AutoSpawnCo()
    {
        while (true)
        {
            SpawnOffset();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    //���� ��ġ ����
    private void SpawnOffset()
    {
        spawnY = Random.Range(columnMin, columnMax);

        Vector2 pos = new Vector2(spawnX, spawnY);
        SpawnPipe(pos);
    }
    //����
    public void SpawnPipe(Vector2 spawnPosition)
    {
        PipeMovement pipe = GetFromPipe();
        pipe.transform.position = spawnPosition;

        pipe.gameObject.SetActive(true);

    }
    //�������� ��ȯ ��ġ�� ������
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
        //��Ȱ��ȭ�� �������� ������ �߰� ����
        var newPipe = Instantiate(pipePrefab, transform);
        newPipe.gameObject.SetActive(false);
        pipes.Add(newPipe);
        return newPipe;
    }
}
