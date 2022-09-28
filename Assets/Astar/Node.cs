using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Node : IComparable
{
    public int GCost;
    public int HCost;

    public Node parent;
    public int movementPenalty;
    public bool istransverable { get; private set; }
    public bool WasVisited { get; set; }

    public int Fcost
    {
        get { return GCost + HCost; }
    }

    public Vector3 worldPos { get; private set; }
    public Vector3Int GridPosition { get; private set; }



    public Node(Vector3 worldposition, Vector3Int gridposition, bool IsTransverable, int MovementPenalty)
    {
        worldPos = worldposition;
        GridPosition = gridposition;
        this.istransverable = IsTransverable;
        this.movementPenalty = MovementPenalty;
    }
    public int CompareTo(object obj)
    {
        Node n = (Node)obj;
        if (n.Fcost < Fcost)
        {
            return 1;
        }

        if (n.Fcost > Fcost)
        {
            return -1;
        }

        return 0;
    }
}


