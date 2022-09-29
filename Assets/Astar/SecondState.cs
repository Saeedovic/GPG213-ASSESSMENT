using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondState : AgentState
{
    public override void UpdateState(AgentManager manager)
    {

        if (manager.firstRun == true)
        {
            manager.astarPF.PathFinder(manager.start2, manager.end2);

            MoveAgent(manager);
        }

        if (manager.tankTwo.transform.position == manager.astarPF.finalpath[manager.astarPF.finalpath.Count - 1].worldPos)
        {
            manager.secondRun = true;
            manager.index = 0;
            
            manager.SwitchState(manager.thirdState);
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
                if (manager.distToObject <= 2)
                {
                    manager.jumped = true;
                    Debug.Log("Jump");

                }
            }

        }
    }

}

