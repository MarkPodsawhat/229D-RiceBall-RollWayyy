using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    Collider collider;
    Material newMaterial;
    MeshRenderer meshRenderer;

    public GameObject face;
    public Camera cam;
    public GameObject camfollower;

    [Header("Speed")]
    public float speed = 5.0f;

    [Header("Camera")]
    public float camX = 0;
    public float camY = 0;
    public float camZ = 0;

    [Header("Material")]
    public Material[] materials;

    [Header("PhysicsMaterial")]
    public PhysicsMaterial[] physicMaterial;

    private InputAction moveAction;
    private InputAction breakAction;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();

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
        cam.transform.position = camfollower.transform.position + new Vector3(camX, camY, camZ);
        cam.transform.LookAt(camfollower.transform.position);

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            camY += 0.5f;
            camZ -= 1.0f;
            if (camY > 3f)
            {
                camY = 3f;
            }
            if (camZ < -6f)
            {
                camZ = -6f;
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            camY -= 0.5f;
            camZ += 1.0f;

            if (camY < 1.5f)
            {
                camY = 1.5f;
            }
            if (camZ > -3f)
            {
                camZ = -3f;
            }
        }
    }

    public void ChangeBallType(int matNo)
    {   
        if (matNo < materials.Length)
        {
            newMaterial = materials[matNo];
            meshRenderer.sharedMaterial = newMaterial;
        }
    }

}
