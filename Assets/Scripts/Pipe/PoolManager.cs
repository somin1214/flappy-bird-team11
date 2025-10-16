
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UIElements.Experimental;


public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }
    
    private Dictionary<string, object> pools = new Dictionary<string, object>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Ǯ ���� �� ��ųʸ� ���
    public void CreatePool<T>(T prefab, int initCount, Transform parent = null) where T :  MonoBehaviour
    {
        if (prefab == null) return;

        string key = prefab.name;
        if (pools.ContainsKey(key)) return;

        pools.Add(key, new ObjectPool<T>(prefab, initCount, parent));


    }
    
    //Ǯ ���(Ȱ��ȭ)
    public T GetFromPool<T>(T prefab) where T : MonoBehaviour
    {
        if (prefab == null) return null;

        if(!pools.TryGetValue(prefab.name, out var box))
        {
            return null;
        }

        var pool = box as ObjectPool<T>;

        if(pool!=null)
        {
            return pool.Dequeue();
        }
        else
        {
            return null;
        }
    }
    
    //Ǯ �ٽ� ����(��Ȱ��ȭ)
    public void ReturnPool<T>(T instance) where T :  MonoBehaviour
    {

        if (instance == null) return;

        if(!pools.TryGetValue(instance.gameObject.name, out var box))
        {
            Destroy(instance.gameObject);
            return;
        }

        var pool = box as ObjectPool<T>;

        if(pool!=null)
        {
            pool.Enqueue(instance);
        }
    }
}
