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
        poolQueue = new Queue<GameObject>();
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
        poolQueue.Clear();
        count = Random.Range(6, 10);

        for (int i = 0; i < count; i++)
        {
            GameObject gameObj = Instantiate(prefab);

            if(i == count - 1)
                gameObj.GetComponent<Knife>().Last = true;

            gameObj.SetActive(false);
            gameObj.transform.parent = parentObject.transform;
            poolQueue.Enqueue(gameObj);
        }
    }

}
