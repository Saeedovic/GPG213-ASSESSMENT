using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public LayerMask unWalkable;
    public float nodeRadius;
    public int cellCountX;
    public int cellCountZ;
    public GameObject gameobject;
    //  public bool walkable;
    Dictionary<int, int> walkableRegionsDictionary =  new Dictionary<int, int>();

    public ObjectType[] walkableRegions;
    LayerMask walkableMask;
    public int cellSizeX;
    public int cellSizeZ;
  //  Node nooode;
    //   public bool IsAnObstacle = false;
    // public AstarPF Pathfinding;

    Node[,] nodes;

    void Start()
    {
        foreach(ObjectType region in walkableRegions)
        {
            walkableMask.value = walkableMask |= region.layerMask.value;
            walkableRegionsDictionary.Add((int)Mathf.Log(region.layerMask.value, 2), region.movementCost);
            
        }
        GridCreator(cellCountX, cellCountZ);

    }


    public void GridCreator(int cellCountX, int cellCountZ)
    {
        nodes = new Node[cellCountX , cellCountZ];

        for (int z = 0; z < cellCountZ; z++)
        {
            for (int x = 0; x < cellCountX; x++)
            {
                int i = x + z * cellCountX;

                Vector3 worldposition = new Vector3 (x * cellSizeX + (cellSizeX / 2.0f), 0, z * cellSizeZ + (cellSizeZ / 2.0f));
              bool walkable = !(Physics.CheckSphere(worldposition, nodeRadius, unWalkable));

                int movementPenalty = 0;

                if (walkable)
                {
                    Ray ray = new Ray(worldposition + Vector3.up * 50, Vector3.down);
                    RaycastHit hit;
                    if(Physics.Raycast(ray, out hit, 100 , walkableMask))
                    {
                        walkableRegionsDictionary.TryGetValue(hit.collider.gameObject.layer, out movementPenalty);
                    }
                }
                nodes[x,z] = new Node(worldposition, new Vector3Int(x, 0, z), walkable, movementPenalty);
                

                /*gameobject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                gameobject.transform.position = nodes[i].worldPos;
                gameobject.transform.localScale = new Vector3(cellSizeX, 0, cellSizeZ) / 3f;*/
              //  gameobject.GetComponent<Collider>().enabled = false;
                
                /* Collider[] hitcolliders = Physics.OverlapSphere(gameObject.transform.position, nodeRadius);
                 if(hitcolliders == GameObject.FindGameObjectsWithTag("Obstacle"))
                 {

                 }*/
                /*  bool walkable = !(Physics.CheckSphere(nodes[i].worldPos, nodeRadius, unWalkable));
                  nodes[x * z] = new Node(new Vector3(x * cellSizeX + (cellSizeX / 2.0f), 0, z * cellSizeZ + (cellSizeZ / 2.0f)), new Vector3Int(x, 0, z), true);
  */

            }
        }


    }

    /* void OnCollision(Node node)
     {
         Collider[] colliders = Physics.OverlapSphere(node.worldPos,nodeRadius);
         foreach (Collider collider in colliders)
         {
             if(collider.transform.parent == obstacles)
             {
                 node.worldPos= false;

             }
         }
     }*/


    public Node GetNode(Vector3Int gridPosition)
    {
        int i = gridPosition.x + gridPosition.z * cellCountX;
        return nodes[gridPosition.x,gridPosition.z];
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
[System.Serializable]
public class ObjectType
{
    public LayerMask layerMask;
    public int movementCost;
}

