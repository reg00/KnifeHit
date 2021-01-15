using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private int count;
    public GameObject prefab;
    public GameObject parentObject;

    [SerializeField]
    public Queue<GameObject> poolQueue;

    public static ObjectPooler Instance;

    private void Awake()
    {
        
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateNewPool();
    }

    public GameObject SpawnFromPool(Vector3 position)
    {
        if (poolQueue.Count == 0)
            return null;

        GameObject objectToSpawn = poolQueue.Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;

        return objectToSpawn;
    }

    public void GenerateNewPool()
    {
        count = Random.Range(6, 10);
        poolQueue = new Queue<GameObject>();

        for (int i = 0; i < count; i++)
        {
            GameObject gameObj = Instantiate(prefab);
            gameObj.SetActive(false);
            gameObj.transform.parent = parentObject.transform;
            poolQueue.Enqueue(gameObj);
        }
    }

}
