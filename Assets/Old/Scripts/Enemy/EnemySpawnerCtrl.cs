using UnityEngine;

public class EnemySpawnerCtrl : MonoBehaviour
{
    public float spawnEnemyOneDelay = 5f;

    private float timerEnemyOne = 0f;

    public float spawnEnemyTwoDelay = 8f;

    private float timerEnemyTwo = 0f;

    private void Update()
    {
        timerEnemyOne += Time.deltaTime;
        timerEnemyTwo += Time.deltaTime;

        if (timerEnemyOne >= spawnEnemyOneDelay)
        {
            SpawnEnemy(EnemySpawner.enemyOne);
            timerEnemyOne = 0f;
        }

        if (timerEnemyTwo >= spawnEnemyTwoDelay)
        {
            SpawnEnemy(EnemySpawner.enemyTwo);
            timerEnemyTwo = 0f;
        }
    }

    private void SpawnEnemy(string enemyName)
    {
        Transform enemy = EnemySpawner.Instance.Spawn(enemyName, transform.position, Quaternion.identity);
        if (enemy == null) return;
        enemy.gameObject.SetActive(true);
    }
}
