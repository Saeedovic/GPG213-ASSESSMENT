using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class AstarPF : MonoBehaviour
{
    [SerializeField] Grid grid;
    List<Node> neighbours;
    List<Node> openList;
    List<Node> closeList;
    public List<Node> finalpath;

    Node currentNode;
    public Node startNode;
    public Node endNode;

    Thread pathfindingThread;
    //bool validPathFound;
    public bool pathAvailable { get; protected set; }


    private void Start()
    {
        neighbours = new List<Node>();
        openList = new List<Node>(100);
        closeList = new List<Node>(100);
        finalpath = new List<Node>(100);

        pathAvailable = false;

        //pathfindingThread.Start();
    }


    // figure out a valid path for agents to use.
    private void FindPath()
    {
        //while (true)
        {

            //while (startNode == null || endNode == null)
            {
                // Thread.Sleep(100);
            }

            // Find path
            PathFinder(startNode.GridPosition, endNode.GridPosition);

            // make sure thread's done and returned true
            //if(!pathfindingThread.IsAlive && validPathFound)
            {

            }
        }
    }


    public void PathFinder(Vector3Int startNodeGrid, Vector3Int endNodeGrid)
    {
        if (pathfindingThread.IsAlive)
        {
            Debug.LogWarning("A* path is already being searched!");

            return; // exit if the thread is already active, so we don't do unwanted stuff to variables.
        }

        pathAvailable = false;
        openList.Clear();

        for (int i = 0; i < closeList.Count; i++)
        {
            closeList[i].parent = null;
            closeList[i].WasVisited = false;
        }

        closeList.Clear();
        neighbours.Clear();
        finalpath.Clear();
        currentNode = null;

        startNode = grid.GetNode(startNodeGrid);
        endNode = grid.GetNode(endNodeGrid);
        currentNode = startNode;
        openList.Add(currentNode);


        pathfindingThread = new Thread(new ThreadStart(CalculateSmallestCost));
        pathfindingThread.Start();

    }


    void CalculateSmallestCost()
    {
        while (openList.Count > 0)
        {

            //  neighbours.Clear();
            openList.Sort();
            currentNode = openList[0];
            openList.RemoveAt(0);
            currentNode.WasVisited = true;
            closeList.Add(currentNode);

            if (currentNode == endNode)
            {
                GetPath(endNode);
                finalpath.Reverse();

                pathAvailable = true;
            }

            CheckNeighbours(currentNode);

            for (int i = 0; i < neighbours.Count; i++)
            {
                if (neighbours[i].istransverable && !neighbours[i].WasVisited)
                {
                    if (!openList.Contains(neighbours[i]))
                    {

                        int cost = CalculateDistance(neighbours[i].GridPosition, startNode.GridPosition) + neighbours[i].movementPenalty;/// check



                        if (cost < neighbours[i].GCost || !openList.Contains(neighbours[i]))
                        {
                            neighbours[i].GCost = cost;
                            neighbours[i].HCost = CalculateDistance(neighbours[i].GridPosition, endNode.GridPosition);

                            neighbours[i].parent = currentNode;

                            if (!openList.Contains(neighbours[i]))
                            {
                                openList.Add(neighbours[i]);
                                closeList.Add(neighbours[i]);
                            }
                        }
                    }
                }

            }
        }

        pathAvailable = false;

    }


    public void CheckNeighbours(Node currentNode)
    {
        neighbours.Clear();

        for (int z = -1; z <= 1; z++)
        {

            for (int x = -1; x <= 1; x++)
            {
                Vector3Int neighbourNodeVect = currentNode.GridPosition + new Vector3Int(x, 0, z);

                if (neighbourNodeVect.x >= 0 && neighbourNodeVect.x < grid.cellCountX && neighbourNodeVect.z >= 0 && neighbourNodeVect.z < grid.cellCountZ)
                {
                    neighbours.Add(grid.GetNode(neighbourNodeVect));
                }

            }

        }

        /* Vector3Int topNode = currentNode.GridPosition + new Vector3Int(0, 0, 1);
         if (topNode.z < grid.cellCountZ)
             neighbours.Add(grid.GetNode(topNode));

         Vector3Int bottomNode = currentNode.GridPosition + new Vector3Int(0, 0, -1);
         if (bottomNode.z >= 0)
             neighbours.Add(grid.GetNode(bottomNode));

         Vector3Int rightNode = currentNode.GridPosition + new Vector3Int(1, 0, 0);
         if (rightNode.x < grid.cellCountX)
             neighbours.Add(grid.GetNode(rightNode));

         Vector3Int LeftNode = currentNode.GridPosition + new Vector3Int(-1, 0, 0);
         if (LeftNode.x >= 0)
             neighbours.Add(grid.GetNode(LeftNode));*/





    }

    int CalculateDistance(Vector3 a, Vector3 b)
    {
        return (int)Mathf.Abs(b.x - a.x) + (int)Mathf.Abs(b.z - a.z);
    }


    void GetPath(Node node)
    {
        finalpath.Add(node);

        Node parent = node.parent;

        if (parent != null)
        {
            GetPath(parent);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < finalpath.Count; i++)
        {
            Gizmos.DrawSphere(finalpath[i].worldPos, 1.1f);

        }

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(startNode.worldPos, 0.5f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(endNode.worldPos, 0.5f);


    }
}