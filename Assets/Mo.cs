using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mo : MonoBehaviour
{

    public float speed = 100f;
    public Rigidbody rb;

    public Vector3 movement;


    void Start()
    {

        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        Move(movement);
    }

    void Move(Vector3 direction)
    {

        rb.velocity = direction * speed * Time.deltaTime;
    }

}
