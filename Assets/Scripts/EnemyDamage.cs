using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem damageFX = null;
    [SerializeField] GameObject deathFX = null;
    [SerializeField] AudioClip deathSX = null;

    private AudioSource audioSource = null;

    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        Instantiate(deathFX, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(deathSX);
        Destroy(gameObject);                            
    }

    private void ProcessHit()
    {
        hitPoints--;
        damageFX.Play();
    }
}
