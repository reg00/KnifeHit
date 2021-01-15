using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject knife;
    ObjectPooler pooler;
    public int throwCount;

    [SerializeField]
    public float force;
    [SerializeField]
    public float pause;
    public GameObject knifePrefab;

    void Start()
    {
        throwCount = 0;
        pooler = ObjectPooler.Instance;
        knife = pooler.SpawnFromPool(transform.position);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && knife != null)
        {
            throwCount++;
            knife.transform.parent = null;
            knife.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
            knife = pooler.SpawnFromPool(transform.position);
        }

        if(knife == null)
        {
            pooler.GenerateNewPool();
            knife = pooler.SpawnFromPool(transform.position);
        }
    }

    public void Lose()
    {
        Debug.Log(throwCount);
        throwCount = 0;
        DestroyOldKnifes();
        pooler.GenerateNewPool();
        knife = pooler.SpawnFromPool(transform.position);
    }

    private void DestroyOldKnifes()
    {
        var wood = GameObject.FindGameObjectWithTag("Wood").transform;
        for (int i = 0; i < wood.childCount; i++)
        {
            Destroy(wood.GetChild(i).gameObject);
        }
    }
}
