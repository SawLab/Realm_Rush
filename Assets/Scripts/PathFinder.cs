using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWayPoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbors();
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping Overlapping block " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
        print(grid.Count);
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWayPoint.SetTopColor(Color.cyan);
    }

    private void ExploreNeighbors()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int nextLocation = startWaypoint.GetGridPos() + direction;
            try
            {
                grid[nextLocation].SetTopColor(Color.magenta);
            }
            catch(KeyNotFoundException e)
            {
                Debug.Log(e + "Neighbor doesn not exist.");
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
