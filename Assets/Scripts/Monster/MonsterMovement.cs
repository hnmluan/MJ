using System.Threading;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public string monsterName;

    public Transform monster;

    public int timeToSpawnAfterDie = 3;

    private void Start()
    {
        Spawn();
    }

    private void Update()
    {
        if (monster.gameObject.activeSelf == false)
        {
            Thread.Sleep(timeToSpawnAfterDie * 1000);
            Spawn();
        }
    }

    public void Spawn()
    {
        Transform monster = MonsterSpawner.Instance.Spawn(monsterName, transform.position, Quaternion.identity);
        if (monster == null) return;
        monster.gameObject.SetActive(true);
    }
}
