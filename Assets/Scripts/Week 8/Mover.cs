using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        transform.Translate(Vector3.back * (speed * Time.deltaTime));
    }
}