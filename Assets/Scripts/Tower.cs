using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan = null;
    [SerializeField][Tooltip("How far away the tower can shoot")] float maxRange = 20;
    [SerializeField] ParticleSystem projectile = null;
    [SerializeField] AudioSource gunFireSX = null;

    public Waypoint baseWaypoint = null;

    private int _numberOfParticles = 0;

    // Update is called once per frame
    void Update()
    {
        LookAtClosestEnemy();
        int particleCount = projectile.particleCount;
        if (particleCount > _numberOfParticles)         //new particle has been created so play firing sound
        {
            gunFireSX.Play();
        }
        _numberOfParticles = particleCount;
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
