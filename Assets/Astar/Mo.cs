using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mo : MonoBehaviour
{
    public AstarPF astar;
    public AgentManager agentManager;

    public float speed = 100f;
    public Rigidbody rb;

    public Vector3 jumpForce;
    public Vector3 movement;


    void Start()
    {
      //  rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, astar.finalpath[astar.finalpath.Count - 2].worldPos, speed * Time.deltaTime);
       // Jump();
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }

    void FixedUpdate()
    {
       // Move(movement);
    }

    void Move(Vector3 direction)
    {

        rb.velocity = direction * speed * Time.deltaTime;
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
        rb.AddForce(jumpForce, ForceMode.Impulse);

        }
    }

}
