using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtClosestEnemy();
    }

    private void LookAtClosestEnemy()
    {
        var enemies = FindObjectsOfType<EnemyMovement>();

        EnemyMovement closestEnemy = null;
        float leastDistance = float.MaxValue;
        
        foreach(var enemy in enemies)
        {
            float distance = Mathf.Sqrt(Mathf.Pow(gameObject.transform.position.x - enemy.gameObject.transform.position.x, 2)
                                        + Mathf.Pow(gameObject.transform.position.z - enemy.transform.position.z, 2));
            if (distance < leastDistance)
            {
                leastDistance = distance;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null) { objectToPan.LookAt(closestEnemy.transform); }       
    }
}
