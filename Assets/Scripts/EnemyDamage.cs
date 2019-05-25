using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem damageFX = null;
    [SerializeField] GameObject deathFX = null;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip deathSX = null;

    [SerializeField] Transform parent;

    void Start()
    {
      
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
        Destroy(mesh);                                      //remove enemy from player view
        Destroy(enemy);                                     //make enemy untargetable by turrets                                            
        Invoke("DeleteGameObject", 3f);                     //Delay delete gameobject to let any sounds or effects complete
    }

    private void ProcessHit()
    {
        hitPoints--;
        damageFX.Play();
    }

    private void DeleteGameObject()
    {
        Destroy(gameObject);
    }
}
