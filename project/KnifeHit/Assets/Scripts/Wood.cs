using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField]
    public float speed;

    void FixedUpdate()
    {
        transform.Rotate(0, 0, speed);
    }
}
