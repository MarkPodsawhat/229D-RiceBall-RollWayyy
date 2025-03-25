using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public GameObject face;
    public Camera cam;

    public float speed = 5.0f;

    public float camX = 0;
    public float camY = 0;
    public float camZ = 0;

    private InputAction moveAction;
    private InputAction breakAction;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
        breakAction = InputSystem.actions.FindAction("Break");
    }

    void Start()
    {
    }

    
    void Update()
    {
        float verticalInput = moveAction.ReadValue<Vector2>().y;
        rb.AddForce(verticalInput * speed * face.transform.forward);

        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        rb.AddForce(horizontalInput * speed * face.transform.right);

        if (breakAction.IsPressed())
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

       
    }

    private void LateUpdate()
    {
        cam.transform.position = transform.position + new Vector3(camX, camY, camZ);
    }
}
