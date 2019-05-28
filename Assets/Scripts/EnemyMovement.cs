using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 2;

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
            float yPos = gameObject.transform.position.y;
            float zPos = topMeshRenderer.transform.position.z;
            transform.position = new Vector3(xPos, yPos, zPos);
            yield return new WaitForSeconds(movementSpeed);
        }
        var enemy = gameObject.GetComponent<EnemyDamage>();
        enemy.KillEnemy();
    }
}
