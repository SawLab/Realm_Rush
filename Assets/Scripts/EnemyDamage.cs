using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem damageFX = null;
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        hitPoints--;
        damageFX.Play();
    }
}
