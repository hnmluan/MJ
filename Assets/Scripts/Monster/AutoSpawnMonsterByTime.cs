using System.Collections;
using UnityEngine;

public class AutoSpawnMonsterByTime : MonoBehaviour
{
    public string monsterName;

    public Transform monster;

    public int timeToSpawnAfterDie = 30;

    public bool isFirst = true;

    private void Awake()
    {
    }

    private IEnumerator Start()
    {
        if (isFirst)
        {
            isFirst = false;
            Spawn();
        }
        if (monster.gameObject.activeSelf == false)
        {
            yield return new WaitForSeconds(timeToSpawnAfterDie);
            Spawn();
        }
    }


    public void Spawn()
    {
        monster = MonsterSpawner.Instance.Spawn(monsterName, transform.position, Quaternion.identity);
        if (monster == null) return;
        monster.gameObject.SetActive(true);
    }
}
