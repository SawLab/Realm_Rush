using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem damageFX = null;
    [SerializeField] GameObject deathFX = null;
    [SerializeField] AudioClip deathSX = null;
    [SerializeField] Transform parent = null;

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

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        audioSource.PlayOneShot(deathSX);
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        EnemyMovement enemy = GetComponent<EnemyMovement>();
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        Destroy(mesh);                                      //remove enemy from player view
        Destroy(enemy);                                     //make enemy untargetable by turrets                                            
        Destroy(rigidBody);                                 //remove physics of object
        Destroy(boxCollider);                               //remove collider so turret shots aren't blocked
        Destroy(gameObject, 3f);                            //Delay destroy gameobject to let any effects finish
        
    }

    private void ProcessHit()
    {
        hitPoints--;
        damageFX.Play();
    }
}
