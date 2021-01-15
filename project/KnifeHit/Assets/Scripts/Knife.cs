using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Rigidbody2D rgdbd;
    public bool InWood;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Wood"))
        {
            rgdbd.velocity = Vector2.zero;
            transform.parent = collision.transform;
            InWood = true;
        }
        else if (collision.gameObject.tag.Equals("Knife"))
        {
            if (collision.gameObject.GetComponent<Knife>().InWood)
            {
                //Проигрыш
            }
        }
    }
}
