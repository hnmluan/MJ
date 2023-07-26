using System.Collections;
using UnityEngine;

public class AutoSpawnEnemyByTime : MonoBehaviour
{
    public string enemyName;

    public Transform enemy;

    public float spawnDelay = 5f;

    private void Start() => StartCoroutine(SpawnEnemy());

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Spawn();

            yield return new WaitUntil(() => enemy == null || !enemy.gameObject.activeSelf);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void Spawn()
    {
        enemy = EnemySpawner.Instance.Spawn(enemyName, transform.position, Quaternion.identity);
        if (enemy == null) return;
        enemy.gameObject.SetActive(true);
    }
}
