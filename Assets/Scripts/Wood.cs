using System.Collections;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField]
    public float speed;

    [SerializeField]
    private float shakeAmt;

    private Animator anim;
    private bool isShaking = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        transform.Rotate(0, 0, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine("Shake");
        anim.SetTrigger("Hit");
    }

    private void Update()
    {
        if(isShaking)
        {
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y + (Random.insideUnitSphere * (Time.deltaTime * shakeAmt)).y);
            transform.position = newPos;
        }
    }

    IEnumerator Shake()
    {
        Vector3 origPos = transform.position;

        if (!isShaking)
            isShaking = true;

        yield return new WaitForSeconds(0.1f);

        isShaking = false;
        transform.position = origPos;
    }
}
