
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

    //풀 생성 및 딕셔너리 등록
    public void CreatePool<T>(T prefab, int initCount, Transform parent = null) where T :  MonoBehaviour
    {
        if (prefab == null) return;

        string key = prefab.name;
        if (pools.ContainsKey(key)) return;

        pools.Add(key, new ObjectPool<T>(prefab, initCount, parent));


    }
    
    //풀 사용(활성화)
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
    
    //풀 다시 넣음(비활성화)
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
