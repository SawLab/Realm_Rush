using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 20;

    void OnTriggerEnter(Collider other)
    {
        if (--playerHealth <= 0)
        {
            Destroy(gameObject);
        }

    }
}
