using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gridy : MonoBehaviour
{
    public bool displayGridGizmos;

    public List<Node> path;

    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public TerrainType[] walkableRegions;
    LayerMask walkableMask;
    Dictionary<int, int> walkableRegionsDictionary = new Dictionary<int, int>();
    Node[,] gridy;
    float nodeDiameter;
    int gridSizeX, gridSizeY;
    void Awake()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);

        foreach (TerrainType region in walkableRegions)
        {
            walkableMask.value |= region.terrainMask.value;
            walkableRegionsDictionary.Add((int)Mathf.Log(region.terrainMask.value, 2), region.terrainPenalty);
        }

        CreateGrid();

    }
    public int MaxSize
    {
        get
        {
            return gridSizeX * gridSizeY;
        }
    }
    void CreateGrid()
    {
        gridy = new Node[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2;
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.up * (y * nodeDiameter + nodeRadius);
                bool walkable = !(Physics2D.OverlapCircle(worldPoint, nodeRadius, unwalkableMask));
                if (!walkable)
                {
                    //Debug.Log("Unwalkable at position: " + worldPoint);
                }
                int movementPenalty = 0;

                if (walkable)
                {
                    Ray ray = new Ray(worldPoint + Vector3.forward * 50, Vector3.back);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 100, walkableMask))
                    {

                        walkableRegionsDictionary.TryGetValue(hit.collider.gameObject.layer, out movementPenalty);
                        Debug.Log(movementPenalty);

                    }

                }

                gridy[x, y] = new Node(walkable, worldPoint, x, y, movementPenalty);
            }
        }
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                {
                    continue;
                }
                int checkX = node.gridX + x;
                int checkY = node.gridY + y;
                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbours.Add(gridy[checkX, checkY]);
                }
            }
        }
        return neighbours;
    }
    public Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.y + gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return gridy[x, y];
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 0));
        if (gridy != null && displayGridGizmos)
        {
            foreach (Node n in gridy)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.red;
                Gizmos.DrawCube(n.worldPosition, Vector2.one * (nodeDiameter - .1f));
            }
        }

    }
    [System.Serializable]
    public class TerrainType
    {
        public LayerMask terrainMask;
        public int terrainPenalty;
    }
}
