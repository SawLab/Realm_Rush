﻿using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerToPlace = null;
    [SerializeField] int towerLimit = 5;
    [SerializeField] GameObject towerParent = null;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint waypoint)
    {
        if (towerQueue.Count < towerLimit)
        {
            InstantiateNewTower(waypoint);
        }
        else
        {
            MoveExistingTower(waypoint);
        }
    }

    private void MoveExistingTower(Waypoint waypoint)
    {
        Tower oldTower = towerQueue.Dequeue();
        oldTower.baseWaypoint.isPlaceable = true;
        oldTower.baseWaypoint = waypoint;
        waypoint.isPlaceable = false;
        Vector3 position = GetNewPosition(waypoint);
        oldTower.transform.position = position;
        towerQueue.Enqueue(oldTower);
    }

    private void InstantiateNewTower(Waypoint waypoint)
    {
        Vector3 position = GetNewPosition(waypoint);
        Tower newTower = Instantiate(towerToPlace, position, Quaternion.identity);
        waypoint.isPlaceable = false;
        newTower.baseWaypoint = waypoint;
        newTower.transform.parent = towerParent.transform;
        towerQueue.Enqueue(newTower);
    }

    private Vector3 GetNewPosition(Waypoint waypoint)
    {
        MeshRenderer topMeshRenderer = waypoint.transform.Find("Top").GetComponent<MeshRenderer>();
        return topMeshRenderer.transform.position;
    }
}
