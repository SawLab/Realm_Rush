using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowWaypoints(path));     
    }

    IEnumerator FollowWaypoints(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            MeshRenderer topMeshRenderer = waypoint.transform.Find("Top").GetComponent<MeshRenderer>();
            float xPos = topMeshRenderer.transform.position.x;
            float zPos = topMeshRenderer.transform.position.z;
            transform.position = new Vector3(xPos, 10f, zPos);
            yield return new WaitForSeconds(1f);
        }
    }
}
