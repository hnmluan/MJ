using System.Collections;
using UnityEngine;

public class AutoSpawnMonsterByTime : MonoBehaviour
{
    public string monsterName;

    public Transform monster;

    public float spawnDelay = 5f;

    private void Start() => StartCoroutine(SpawnEnemy());

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Spawn();

            yield return new WaitUntil(() => monster == null || !monster.gameObject.activeSelf);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void Spawn()
    {
        monster = MonsterSpawner.Instance.Spawn(monsterName, transform.position, Quaternion.identity);
        if (monster == null) return;
        monster.gameObject.SetActive(true);
    }
}
