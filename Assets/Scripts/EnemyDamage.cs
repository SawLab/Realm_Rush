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
        DestroyComponents();
        Destroy(gameObject, 2f);                            
    }

    private void ProcessHit()
    {
        hitPoints--;
        damageFX.Play();
    }
    private void DestroyComponents()
    {
        Destroy(gameObject.GetComponent<MeshRenderer>());
        Destroy(gameObject.GetComponent<Rigidbody>());
        Destroy(gameObject.GetComponent<BoxCollider>());
        Destroy(gameObject.GetComponent<EnemyMovement>());
        var particles = gameObject.GetComponentsInChildren<ParticleSystem>();

        foreach(var particle in particles)
        {
            Destroy(particle);
        }
    }
}
