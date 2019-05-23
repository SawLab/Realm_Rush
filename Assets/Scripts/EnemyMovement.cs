using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AddBoxCollider();
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
            float yPos = gameObject.transform.position.y;
            float zPos = topMeshRenderer.transform.position.z;
            transform.position = new Vector3(xPos, yPos, zPos);
            yield return new WaitForSeconds(1.5f);
        }
    }

    private void AddBoxCollider()
    {
        Collider enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyBoxCollider.isTrigger = false;
    }

}
