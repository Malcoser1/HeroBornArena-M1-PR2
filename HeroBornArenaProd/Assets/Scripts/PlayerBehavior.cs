using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // 1
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    // 2
    private float vInput;
    private float hInput;

    // 3
    private Rigidbody _rb;
    // 4
    void Start()
    {
        // 5
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 6
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        // 7 
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        // 8
        this.transform.Translate(Vector3.forward * vInput *
        Time.deltaTime);
        // 9
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
    }

    // 10
    void FixedUpdate()
    {
        // 11
        Vector3 rotation = Vector3.up * hInput;
        // 12
        Quaternion angleRot = Quaternion.Euler(rotation *
        Time.fixedDeltaTime);
        // 13
        _rb.MovePosition(this.transform.position +
        this.transform.forward * vInput * Time.fixedDeltaTime);
        // 14
        _rb.MoveRotation(_rb.rotation * angleRot);
    }

}