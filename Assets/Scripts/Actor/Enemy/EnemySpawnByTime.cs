using System.Collections;
using UnityEngine;

public class EnemySpawnByTime : MonoBehaviour
{
    [SerializeField] protected EnemyCode enemyCode = EnemyCode.NoEnemy;

    [SerializeField] protected float spawnDelay = 5f;

    protected Transform enemy;

    protected void Start() => StartCoroutine(SpawnEnemy());

    protected IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Spawn();
            yield return new WaitUntil(() => enemy == null || !enemy.gameObject.activeSelf);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    protected void Spawn()
    {
        enemy = EnemySpawner.Instance.Spawn(enemyCode.ToString(), transform.position, Quaternion.identity);
        if (enemy == null) return;
        enemy.gameObject.SetActive(true);
    }
}
