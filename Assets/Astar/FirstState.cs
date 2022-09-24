using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstState : AgentState
{
    

    public override void UpdateState(AgentManager manager)
    {


        if (Input.GetKeyDown(KeyCode.Space))
            manager.astarPF.PathFinder(manager.start, manager.end);

        MoveAgent(manager);
        if (manager.index == 3)
        {
            manager.onIndex = true;
        }


        if (manager.tank.transform.position == manager.astarPF.finalpath[manager.astarPF.finalpath.Count - 1].worldPos)
        {
            manager.done = true;
            manager.index = 0;
            // manager.astarPF.PathFinder(manager.start2, manager.end2);
            manager.SwitchState(manager.secondState);
        }
    }

    public void MoveAgent(AgentManager manager)
    {

        manager.tank.transform.position = Vector3.MoveTowards(manager.tank.transform.position, manager.astarPF.finalpath[manager.index].worldPos, manager.speed * Time.deltaTime);
        if (manager.tank.transform.position == manager.astarPF.finalpath[manager.index].worldPos)
        {
            if (manager.index <= manager.astarPF.finalpath.Count)
            {
                manager.index++;
                if (manager.distToObject <= manager.range)
                {

                    Jump(manager);
                }

            }
            /* if (manager.transform.position != manager.astarPF.finalpath[manager.astarPF.finalpath.Count - 1].worldPos)
             {

                 manager.transform.position = Vector3.MoveTowards(manager.transform.position, manager.astarPF.finalpath[manager.index].worldPos, manager.speed * Time.deltaTime);
             }*/

        }
    }

    public void Jump(AgentManager manager)
    {
        manager.rb.velocity += manager.jumpHeight;
    }
}
