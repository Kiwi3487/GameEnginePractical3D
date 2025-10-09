using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;   
    public float distance = 5f;     
    public float height = 2f;       
    public float rotationSpeed = 150f; 
    public float smoothTime = 0.1f; 

    private float currentYaw = 0f;
    private float currentPitch = 15f;
    private Vector3 currentVelocity = Vector3.zero;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (target == null) return;
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        currentYaw += mouseX;
        currentPitch = Mathf.Clamp(currentPitch + mouseY, -20f, 60f);
        
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0f);
        Vector3 desiredPosition = target.position - (rotation * Vector3.forward * distance) + Vector3.up * height;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothTime);
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
