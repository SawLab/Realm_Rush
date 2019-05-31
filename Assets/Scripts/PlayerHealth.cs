using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 20;
    [SerializeField] Text healthText = null;

    void Start()
    {
        healthText.text = playerHealth.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        playerHealth--;
        healthText.text = playerHealth.ToString();
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
            Destroy(FindObjectOfType<EnemySpawner>());  //stop spawning enemies

            var enemies = FindObjectsOfType<EnemyMovement>();
            foreach (var enemy in enemies)
            {
                Destroy(enemy.GetComponent<EnemyMovement>());   //stop enemy movement
            }
        }

    }
}
