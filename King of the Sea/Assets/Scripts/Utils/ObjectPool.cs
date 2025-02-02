using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //instanciando objeto
    [SerializeField]
    protected GameObject ObjectToPool;

    [SerializeField]
    protected int poolSize = 10;

    protected Queue<GameObject> objectPool;

    public Transform spawnedObjectsParent;

    private void Awake()
    {
        objectPool = new Queue<GameObject>();
    }

    //Para iniciar o codio
    public void Initialize(GameObject objectToPool, int poolSize = 10)
    {
        this.ObjectToPool = objectToPool;
        this.poolSize = poolSize;
    }

    //verifica se tem menos objetos que o limite permitido para nao lagar
    //e spawna o objeto
    public GameObject CreateObject()
    {
        CreateObjectParentIfNeed();

        GameObject spawnedObject = null;

        if (objectPool.Count < poolSize)
        {
            spawnedObject = Instantiate(ObjectToPool, transform.position, Quaternion.identity);
            spawnedObject.name = transform.root.name + "_" + ObjectToPool.name + "_" + objectPool.Count;
            spawnedObject.transform.SetParent(spawnedObjectsParent);
            spawnedObject.AddComponent<DestryIfDisable>();
        }
        else
        {
            spawnedObject = objectPool.Dequeue();
            spawnedObject.transform.position = transform.position;
            spawnedObject.transform.rotation = Quaternion.identity;
            spawnedObject.SetActive(true);
        }

        objectPool.Enqueue(spawnedObject);
        return spawnedObject;
    }

    //cria um gameobject para armazenar esses objetos se ele nao existe
    private void CreateObjectParentIfNeed()
    {
        if (spawnedObjectsParent == null)
        {
            string name = "ObjectPool_" + ObjectToPool.name;
            var parentObject = GameObject.Find(name);
            if (parentObject != null)
            {
                spawnedObjectsParent = parentObject.transform;
            }
            else
            {
                spawnedObjectsParent = new GameObject(name).transform;
            }
        }
    }

    //destroi objeto antigo se estiver no limite
    private void OnDestroy()
    {
        foreach (var item in objectPool)
        {
            if (item == null)
                continue;
            else if (item.activeSelf == true)
                Destroy(item);
            else
                item.GetComponent<DestryIfDisable>().SelfDestructionEnable = true;

        }
    }
}
