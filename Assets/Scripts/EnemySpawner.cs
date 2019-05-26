using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement objectToSpawn = null;

    [SerializeField] GameObject enemyParent = null;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnGameObject());
    }

    IEnumerator SpawnGameObject()
    {
        while (true)    //forever
        {
            var enemy = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            enemy.transform.parent = enemyParent.transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
