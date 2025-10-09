using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveDistance = 2f;

    public void Move(Vector3 direction)
    {
        transform.position += direction * moveDistance;
    }

    public void MoveBack(Vector3 direction)
    {
        transform.position -= direction * moveDistance;
    }
}