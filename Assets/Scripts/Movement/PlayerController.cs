using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private Invoker invoker;

    private Vector3 lastPosition;
    private bool isGrounded;
    [HideInInspector] public bool isUndoing = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        invoker = FindObjectOfType<Invoker>();
        lastPosition = transform.position;
    }

    void Update()
    {
        if (isUndoing) return; 
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0, v).normalized * moveSpeed;
        Vector3 velocity = transform.TransformDirection(move);
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
        if (!isUndoing && Vector3.Distance(lastPosition, transform.position) > 0.5f)
        {
            invoker.ExecuteCommand(new MoveCommands(this, lastPosition, transform.position));
            lastPosition = transform.position;
        }
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            invoker.Undo();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
    public IEnumerator SmoothMoveTo(Vector3 targetPos, float duration = 0.3f)
    {
        isUndoing = true;
        rb.isKinematic = true;

        Vector3 startPos = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        lastPosition = transform.position;

        rb.isKinematic = false;
        isUndoing = false;
    }
}
