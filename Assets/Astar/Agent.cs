using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Node node;
    public Clock clock;
    public AstarPF astarPF;
  //  public GameObject main;
    // public Vector3Int target;
    public Transform targetTransform;

    public int index;

    public Vector3 jumpForce;
    
    public Rigidbody rb;
    public float speed;
    public Vector3Int start;
    public Vector3Int end;
    //public Vector3Int end2;

    public bool overtime = false;


    void Start()
    {
        // clock = GetComponent<Clock>();
        //  transform.position = start;
        // TimeCheck();
        // targetTransform.position = end;
        //main.transform.position = target;
/**/

       


    }

    void Update()
    {
        IFindPath();
        MoveAgent();

    }

    public void IFindPath()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            astarPF.PathFinder(start, end);

        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            astarPF.PathFinder(end, start);
        }

    }

    public void Jump()
    {
         rb.AddForce(jumpForce, ForceMode.Impulse);
    }

    public void MoveAgent()
    {

        transform.position = Vector3.MoveTowards(transform.position, astarPF.finalpath[index].worldPos, speed * Time.deltaTime);
        if (transform.position == astarPF.finalpath[index].worldPos)
        {
            if (index <= astarPF.finalpath.Count)
            {
                index++;
            }
            if (transform.position != astarPF.finalpath[astarPF.finalpath.Count - 1].worldPos)
            {

                transform.position = Vector3.MoveTowards(transform.position, astarPF.finalpath[index].worldPos, speed * Time.deltaTime);
            }

          /*  if(index == astarPF.finalpath.Count)
            {
                index = 0;
            }*/

        }

        /* public void TimeCheck()
         {
             if(clock.hour > 1)
             {
                 overtime = true;
             }


         }*/
    }
}



