using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawnerInRandomPoint : MonoBehaviour
{
    public PolygonCollider2D polygonCollider;
    public List<GameObject> objectsToSpawn;
    public int numberOfObjects;
    public float spawnInterval = 1f; // Khoảng thời gian giữa các lần sinh ra đối tượng
    public Transform holder;
    private float timer; // Biến đếm thời gian

    private void Start()
    {
        if (polygonCollider == null) return;

        timer = spawnInterval; // Khởi tạo giá trị ban đầu của timer

    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnObject(); // Gọi hàm SpawnObject
            timer = spawnInterval; // Reset timer về giá trị spawnInterval
        }
    }

    private void SpawnObject()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject objectToSpawn = GetRandomObject();
            if (objectToSpawn != null)
            {
                Vector3 spawnPosition = GetRandomPointInPolygon();
                GameObject spawnObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                spawnObject.transform.parent = holder;
                spawnObject.SetActive(true);
            }
        }
    }

    private GameObject GetRandomObject()
    {
        if (objectsToSpawn.Count == 0) return null;

        int randomIndex = Random.Range(0, objectsToSpawn.Count);

        return objectsToSpawn[randomIndex];
    }

    public Vector2 GetRandomPointInPolygon()
    {
        Vector2 randomPoint = new Vector2(
            Random.Range(polygonCollider.bounds.min.x, polygonCollider.bounds.max.x),
            Random.Range(polygonCollider.bounds.min.y, polygonCollider.bounds.max.y)
        );

        Vector2 closestPoint = polygonCollider.ClosestPoint(randomPoint);

        return closestPoint;
    }
}
