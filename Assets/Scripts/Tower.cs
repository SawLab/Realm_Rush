using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField][Tooltip("How far away the tower can shoot")] float maxRange;
    [SerializeField] ParticleSystem projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtClosestEnemy();
    }

    private void FireAtEnemy(bool isActive)
    {
        var emmisionModule = projectile.emission;
        emmisionModule.enabled = isActive;
    }

    private void LookAtClosestEnemy()
    {
        var enemies = FindObjectsOfType<EnemyMovement>();

        EnemyMovement closestEnemy = null;
        float leastDistance = float.MaxValue;
        
        foreach(var enemy in enemies)
        {
            float distance = Vector3.Distance(gameObject.transform.position, enemy.transform.position);
       
            if (distance < leastDistance && distance < maxRange)
            {
                leastDistance = distance;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            objectToPan.LookAt(closestEnemy.transform);
            FireAtEnemy(true);                          //fire at targetted enemy in range
        }
        else
        {
            FireAtEnemy(false);                         //stop firing if no enemy to target in range
        }
    }
}
