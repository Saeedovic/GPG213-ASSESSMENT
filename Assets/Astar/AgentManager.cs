using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    public Node node;
    public AstarPF astarPF;

    public FirstState firstState = new FirstState();
    public SecondState secondState = new SecondState();

    public Transform targetTransform;

    public GameObject tankOne;
    public GameObject tankTwo;
  //  public GameObject tankThree;
    public int index;
    public Rigidbody rb;
    public float speed;
    public Vector3Int start;
    public Vector3Int end;
    public Vector3Int start2;
    public Vector3Int end2;

    public bool done;

    AgentState currentState;
    void Start()
    {
        currentState = firstState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);

    }

    public void SwitchState(AgentState agentState)
    {
        currentState = agentState;
    }
}
