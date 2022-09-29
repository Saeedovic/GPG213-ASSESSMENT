using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    //public Node node;
    public AstarPF astarPF;
    public bool onIndex;
    public bool jumped;

    public float distToObject;
    public Vector3 jumpForce;
    public float range;
    public float jumpHeight;

    public FirstState firstState = new FirstState();
    public SecondState secondState = new SecondState();
    public ThirdState thirdState = new ThirdState();


    //  public Transform targetTransform;

    public GameObject obstacle;

    public GameObject tank;
    public GameObject tankTwo;
    public GameObject jump;
    public float speed;
    //  public GameObject tankTwo;
    //  public GameObject tankThree;
    public int index;
    public Rigidbody rb;
    public Set settings;
    public Vector3Int start;
    public Vector3Int end;
    public Vector3Int start2;
    public Vector3Int end2;
    public Vector3Int start3;
    public Vector3Int end3;

    public bool firstRun;
    public bool secondRun;
    public bool thirdRun;

    AgentState currentState;
    void Start()
    {
        currentState = firstState;
    }

    // Update is called once per frame
    void Update()
    {
        distToObject = Vector3.Distance(this.transform.position, jump.transform.position);
       
        currentState.UpdateState(this);

    }

    public void SwitchState(AgentState agentState)
    {
        currentState = agentState;
    }


   /* private void OnCollisionEnter(Collision collision)
    {
        if (distToObject 
        {
            jumped = true;

        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jump"))
        {

            jumped = false;

        }
    }
*/
}
