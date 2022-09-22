using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Node node;
   public Clock clock;
    public AstarPF astarPF;
    public GameObject main;
    public Vector3Int target;
  
    public float speed;
    public Vector3Int start;
    public Vector3Int end;
    public bool overtime = false;
    void Start()
    {
        // clock = GetComponent<Clock>();
        // transform.position = start;
        // TimeCheck();
        target = end;
        main.transform.position = target;

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
         
            astarPF.PathFinder(start, target);
            
        }
       
    }

    public void MoveAgent()
    {
        transform.position = Vector3.MoveTowards(transform.position, astarPF.finalpath[astarPF.finalpath.Count - 1].worldPos, speed * Time.deltaTime);


    }

   /* public void TimeCheck()
    {
        if(clock.hour > 1)
        {
            overtime = true;
        }


    }*/
}



