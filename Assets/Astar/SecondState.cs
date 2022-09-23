using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondState : AgentState
{
    public override void UpdateState(AgentManager manager)
    {

        if (manager.done == true)
        {
            manager.astarPF.PathFinder(manager.start2, manager.end2);

            MoveAgent(manager);
        }

    }

    public void MoveAgent(AgentManager manager)
    {

        manager.tankTwo.transform.position = Vector3.MoveTowards(manager.tankTwo.transform.position, manager.astarPF.finalpath[manager.index].worldPos, manager.speed * Time.deltaTime);
        if (manager.tankTwo.transform.position == manager.astarPF.finalpath[manager.index].worldPos)
        {
            if (manager.index <= manager.astarPF.finalpath.Count)
            {
                manager.index++;
            }

        }
    }

}

