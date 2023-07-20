using System.Collections;
using UnityEngine;

public class AutoSpawnMonsterByTime : MonoBehaviour
{
    public string monsterName;

    public Transform monster;

    public int timeToSpawnAfterDie = 1;

    public bool isFirst = true;

    private void Awake()
    {
        if (isFirst)
        {
            isFirst = false;
            Spawn();
            Debug.Log("hello");
        }
    }

    private void Start()
    {
        StartCoroutine(Spawn02());
    }

    private IEnumerator Spawn01()
    {
        if (monster.gameObject.activeSelf == false && isFirst == false)
        {
            Debug.Log("die");
            yield return new WaitForSeconds(timeToSpawnAfterDie);
            Spawn();
        }
    }

    private IEnumerator Spawn02()
    {
        while (true)
        {
            if (monster.gameObject.activeSelf == false)
                yield return new WaitForSeconds(timeToSpawnAfterDie);
            Spawn();
        }
    }

    private void Update()
    {
        if (monster == null || monster.gameObject.activeSelf == false)
        {

        }
        Debug.Log(monster.gameObject.activeSelf);
    }


    public void Spawn()
    {
        monster = MonsterSpawner.Instance.Spawn(monsterName, transform.position, Quaternion.identity);
        if (monster == null) return;
        monster.gameObject.SetActive(true);
    }
}
