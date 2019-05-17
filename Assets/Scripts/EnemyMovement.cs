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
            float xPos = waypoint.transform.position.x;
            float yPos = waypoint.transform.localScale.y / 2;
            float zPos = waypoint.transform.position.z;
            transform.position = new Vector3(xPos, yPos, zPos);
            yield return new WaitForSeconds(1f);
        }
    }
}
