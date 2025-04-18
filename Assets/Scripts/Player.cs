﻿using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    Material newMaterial;
    MeshRenderer meshRenderer;
    SphereCollider sphereCollider;

    public GameObject face;
    public Camera cam;
    public GameObject camfollower;

    [Header("Movement")]
    public float forceMag = 10.0f;
    public float maxSpeed = 10.0f;
    public float deceleration = 2.0f;

    [Header("Camera")]
    public Vector3 camOffSet;

    [SerializeField] public BallStat[] ballTypes;

    private InputAction moveAction;
    private InputAction breakAction;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        sphereCollider = GetComponent<SphereCollider>();

        moveAction = InputSystem.actions.FindAction("Move");
        breakAction = InputSystem.actions.FindAction("Break");
    }
    
    void FixedUpdate()
    {
        // รับอินพุตจากผู้เล่น
        float verticalInput = moveAction.ReadValue<Vector2>().y;
        float horizontalInput = moveAction.ReadValue<Vector2>().x;

        // คำนวณแรงจากอินพุต F
        float forceVertical = forceMag * verticalInput;
        float forceHorizontal = forceMag * horizontalInput;

        // คำนวณความเร่งจาก a = F/m (F = ma) 
        float accelVer = forceVertical / rb.mass;
        float accelHor = forceHorizontal / rb.mass;

        // คำนวณความเร่งใหม่
        Vector3 accel = (face.transform.forward * accelVer) + (face.transform.right * accelHor);

        // เพิ่มความเร่งให้ลูกบอล
        rb.AddForce(accel, ForceMode.Acceleration);

        // จำกัดความเร็วไม่ให้เกินค่าที่กำหนด
        rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);
        rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, maxSpeed);
        
        //กดหยุด Break
        if (breakAction.IsPressed())
        {
            rb.linearVelocity = Vector3.MoveTowards(rb.linearVelocity, Vector3.zero, Time.deltaTime * deceleration);
            rb.angularVelocity = Vector3.MoveTowards(rb.angularVelocity, Vector3.zero, Time.deltaTime * deceleration);
        }

    }

    private void LateUpdate()
    {
        CamController();
    }

    public void CamController()
    {
        cam.transform.position = camfollower.transform.position + camOffSet;
        cam.transform.LookAt(transform.position);
    }

    public void ChangeBallType(int i)
    {   
        if (i < ballTypes.Length)
        {
            newMaterial = ballTypes[i].material;
            meshRenderer.sharedMaterial = newMaterial;

            sphereCollider.material = ballTypes[i].physicMaterial;

            rb.mass = ballTypes[i].mass;
            rb.linearDamping = ballTypes[i].linearDamping;
            rb.angularDamping = ballTypes[i].angularDamping;
            
        }
    }

}
