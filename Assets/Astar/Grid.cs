using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    
    public int cellCountX;
    public int cellCountZ;

    public int cellSizeX;
    public int cellSizeZ;

 //   public bool IsAnObstacle = false;
   // public AstarPF Pathfinding;

    Node[] nodes;

    void Start()
    {
        GridCreator(cellCountX, cellCountZ);

    }


    public void GridCreator(int cellCountX, int cellCountZ)
    {
        nodes = new Node[cellCountX * cellCountZ];

        for (int z = 0; z < cellCountZ; z++)
        {
            for (int x = 0; x < cellCountX; x++)
            {
                int i = x + z * cellCountX;
                nodes[i] = new Node(new Vector3(x * cellSizeX + (cellSizeX / 2.0f), 0, z * cellSizeZ + (cellSizeZ / 2.0f)), new Vector3Int(x, 0, z), true);

                GameObject gameobject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameobject.transform.position = nodes[i].worldPos;
                gameobject.transform.localScale = new Vector3(cellSizeX, 0, cellSizeZ) / 3f;
                gameobject.GetComponent<Collider>().enabled = false;


            }
        }


    }

  /*  public void OnCollisionEnter(Collision other)
    {
        if (other.collider == Cube)
        {
            IsAnObstacle = true;
        }
    }*/


    public Node GetNode(Vector3Int gridPosition)
    {
        int i = gridPosition.x + gridPosition.z * cellCountX;
        return nodes[i];
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 25f);
        for (int x = 0; x < cellCountX + 1; x++)
        {
            Gizmos.DrawLine((transform.position + new Vector3(x * cellSizeX, 0, 0)), new Vector3(x * cellSizeX, 0, cellSizeZ * cellCountZ));
        }
        for (int z = 0; z < cellCountZ + 1; z++)
        {
            Gizmos.DrawLine((transform.position + new Vector3(0, 0, z * cellSizeZ)), new Vector3(cellSizeX * cellCountX, 0, z * cellSizeZ));
        }
    }





}
