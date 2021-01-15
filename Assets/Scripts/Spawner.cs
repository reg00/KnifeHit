using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject knife;
    
    [SerializeField]
    public float force;
    [SerializeField]
    public float pause;
    public GameObject knifePrefab;

    void Start()
    {
        knife = Instantiate(knifePrefab, transform);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            knife.transform.parent = null;
            knife.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
            knife = Instantiate(knifePrefab, transform);
        }
    }
}
