using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerToPlace = null;
    [SerializeField] int towerLimit = 5;

    Queue<Tower> towerQueue = new Queue<Tower>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        Tower towerToDelete = towerQueue.Dequeue();
        towerToDelete.baseWaypoint.isPlaceable = true;
        Destroy(towerToDelete.gameObject);
        InstantiateNewTower(waypoint);
    }

    private void InstantiateNewTower(Waypoint waypoint)
    {
        MeshRenderer topMeshRenderer = waypoint.transform.Find("Top").GetComponent<MeshRenderer>();
        Vector3 position = topMeshRenderer.transform.position;
        Tower newTower = Instantiate(towerToPlace, position, Quaternion.identity);
        waypoint.isPlaceable = false;
        newTower.baseWaypoint = waypoint;
        towerQueue.Enqueue(newTower);
    }
}
