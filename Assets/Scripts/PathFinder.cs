using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint = null, endWayPoint = null;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Queue<Waypoint> queue = new Queue<Waypoint>();
    private List<Waypoint> pathToTake = new List<Waypoint>();

    bool isRunning = true;

    Waypoint searchCenter;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

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
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWayPoint.SetTopColor(Color.red);
    }

    private void ExploreNeighbors()
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighborCoordinates))
            {
                QueueNewNeighbors(neighborCoordinates);
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = grid[neighborCoordinates];

        if (neighbor.isExplored || queue.Contains(neighbor)) { return; } //do nothing if explored or already in queue

        queue.Enqueue(neighbor);
        neighbor.exploredFrom = searchCenter;
        searchCenter.isExplored = true;
    }

    private void  PathFind()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            CheckIfFinished();
            ExploreNeighbors();
        }
    }

    private void CheckIfFinished()
    {
        if (searchCenter.Equals(endWayPoint))
        {
            isRunning = false;          

            Waypoint nextWaypoint = endWayPoint;
            pathToTake.Add(nextWaypoint);

            while (nextWaypoint.exploredFrom != null)
            {
                pathToTake.Add(nextWaypoint.exploredFrom);
                nextWaypoint = nextWaypoint.exploredFrom;
            }

            pathToTake.Reverse();
        }
    }

    public List<Waypoint> GetPath()
    {
        if (pathToTake.Count == 0)
        {
            LoadBlocks();
            ColorStartAndEnd();
            PathFind();
        }
        return pathToTake;
    }
}
