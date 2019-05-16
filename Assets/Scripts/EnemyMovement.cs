using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = null;

    // Start is called before the first frame update
    void Start()
    {       
        StartCoroutine(FollowWaypoints());     
    }

    IEnumerator FollowWaypoints()
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            print("Visiting block: " + waypoint.name);
            float xPos = waypoint.transform.position.x;
            float yPos = waypoint.transform.localScale.y / 2;
            float zPos = waypoint.transform.position.z;
            transform.position = new Vector3(xPos, yPos, zPos);
            yield return new WaitForSeconds(1f);
        }
        print("Ending patrol.");
    }
}
