using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement objectToSpawn = null;
    [SerializeField] GameObject enemyParent = null;
    [SerializeField] Text scoreText = null;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        StartCoroutine(SpawnGameObject());
    }

    IEnumerator SpawnGameObject()
    {
        while (true)    //forever
        {
            var enemy = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            enemy.transform.parent = enemyParent.transform;
            IncrementScore();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
