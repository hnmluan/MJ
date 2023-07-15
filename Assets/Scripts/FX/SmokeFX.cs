using UnityEngine;

public class SmokeFX : MonoBehaviour
{
    public float spawnIntervalMin = 0.3f;

    public float spawnIntervalMax = 0.8f;

    public float spawnIntervalCurrent = 0.8f;

    private float timer = 0f;

    private void Start()
    {
        spawnIntervalCurrent = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnIntervalCurrent)
        {
            SpawnSmokeFX();
            timer = 0f;
            spawnIntervalCurrent = Random.Range(spawnIntervalMin, spawnIntervalMax);
        }
    }

    private void SpawnSmokeFX()
    {
        Transform smokeFX = FXSpawner.Instance.Spawn("Smoke", transform.position, Quaternion.identity);
        if (smokeFX == null) return;
        smokeFX.gameObject.SetActive(true);
    }
}
