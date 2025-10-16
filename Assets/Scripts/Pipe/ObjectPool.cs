using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T: MonoBehaviour
{
    private T prefab;
    private Queue<T> pool = new Queue<T>(); 

    public Transform Root { get; private set; } 
    
    //Ǯ ������
    public ObjectPool(T prefab, int initCount, Transform parent = null)
    {
        this.prefab = prefab;
        Root = new GameObject($"{prefab.name}_pool").transform;

        if(parent!=null)
        {
            Root.SetParent(parent, false);
        }

        for(int i = 0;i<initCount;i++)
        {
            var inst = Object.Instantiate(prefab, Root);
            inst.name = prefab.name;
            inst.gameObject.SetActive(false);
            pool.Enqueue(inst);
        }
    }
    
    public T Dequeue()
    {
        if (pool.Count == 0) return null;

        var inst = pool.Dequeue();
        inst.gameObject.SetActive(true);
        return inst;
    }
    
    public void Enqueue(T instance)
    {
        if (instance == null) return;

        instance.gameObject.SetActive(false);
        pool.Enqueue(instance);
    }
}
