using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdState : AgentState
{
    public override void UpdateState(AgentManager manager)
    {
        if (manager.secondRun == true && manager.settings.minute < 30)
        {
            manager.astarPF.PathFinder(manager.end, manager.end3);
            MoveTank(manager);

        }
        else if (manager.secondRun == true && manager.settings.hour > 30)
        {
            manager.thirdRun = true;
            manager.astarPF.PathFinder(manager.end2, manager.end3);
            MoveTankTwo(manager);
        }

            /*if (manager.tank.transform.position == manager.astarPF.finalpath[manager.astarPF.finalpath.Count - 1].worldPos)
            {
                manager.thirdRun = true;
                manager.astarPF.PathFinder(manager.start3, manager.end3);
                MoveTankTwo(manager);


            }*/

    }
    public void MoveTank(AgentManager manager)
    {


        manager.tank.transform.position = Vector3.MoveTowards(manager.tank.transform.position, manager.astarPF.finalpath[manager.index].worldPos, manager.speed * Time.deltaTime);
        if (manager.tank.transform.position == manager.astarPF.finalpath[manager.index].worldPos)
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

    public void MoveTankTwo(AgentManager manager)
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
