using System.Collections;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Rigidbody2D rgdbd;
    public bool InWood;
    public bool Last = false;

    private void Awake()
    {
        GetComponent<TrailRenderer>().sortingLayerName = "Knife";
        GetComponent<TrailRenderer>().sortingOrder = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Wood": CollisionWithWood(collision); break;
            case "Knife": CollisionWithKnife(collision); break;
            case "Apple": CollisionWithApple(collision); break;
        }
    }

    private void CollisionWithWood(Collider2D collision)
    {
        rgdbd.velocity = Vector2.zero;
        InWood = true;
        GetComponent<Knife>().enabled = false;
        StartCoroutine(WaitTrail());

        transform.parent = collision.transform;
        Manager.instance.AddThrow();

        if (Last)
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().OpenNextLvlUI();
    }

    private void CollisionWithKnife(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Knife>().InWood)
        {
            StartCoroutine(WaitTrail());
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().OpenLoseUI();
        }
    }

    private void CollisionWithApple(Collider2D collision)
    {
        if (GetComponent<Knife>().enabled)
            collision.gameObject.SetActive(false);
    }

    IEnumerator WaitTrail()
    {
        yield return new WaitForSeconds(0.25f);
        GetComponent<TrailRenderer>().enabled = false;
    }
}
