using UnityEngine;
using System.Collections;

public class SpawnerManager : MonoBehaviour
{
    public GameObject bombPrefab;
    public GameObject[] bugPrefabs;

    public Transform[] bombSpawnPoints; // Mảng chứa các vị trí spawn bom.
    public Transform[] bugSpawnPoints;  // Mảng chứa các vị trí spawn bọ.

    public float bombSpawnInterval = 5f; // Thời gian giữa hai lần sinh bom (số giây).
    public float bugSpawnInterval = 10f;  // Thời gian giữa hai lần sinh bọ (số giây).

    private bool canSpawnBomb = true;
    private bool canSpawnBug = true;
    public float speed = 2f;
    void Start()
    {
        // Bắt đầu hai coroutine cho bom và bọ.
        StartCoroutine(SpawnBombs());
        StartCoroutine(SpawnBugs());
        StartCoroutine(CountDownAndChangeSpeed());
    }

    IEnumerator SpawnBombs()
    {
        while (true)
        {
            if (canSpawnBomb)
            {
                int randomIndex = Random.Range(0, bombSpawnPoints.Length);
                Vector3 spawnPosition = bombSpawnPoints[randomIndex].position;
                spawnPosition.y += 7f;

                Instantiate(bombPrefab, spawnPosition , Quaternion.identity);
                canSpawnBomb = false;

                yield return new WaitForSeconds(bombSpawnInterval);
                canSpawnBomb = true;
            }

            yield return null;
        }
    }

    IEnumerator SpawnBugs()
    {
        while (true)
        {
            if (canSpawnBug)
            {
                int randomBugIndex = Random.Range(0, bugPrefabs.Length);
                int randomSpawnIndex = Random.Range(0, bugSpawnPoints.Length);

                GameObject randomBugPrefab = bugPrefabs[randomBugIndex];
                Vector3 spawnPosition = bugSpawnPoints[randomSpawnIndex].position;
                spawnPosition.y -= 7f;
                Instantiate(randomBugPrefab, spawnPosition, Quaternion.identity);
                canSpawnBug = false;

                yield return new WaitForSeconds(bugSpawnInterval);
                canSpawnBug = true;
            }

            yield return null;
        }
    }

    IEnumerator CountDownAndChangeSpeed()
    {
        speed = 2f;
        while (true)
        {
            yield return new WaitForSeconds(10f);

            // Thay đổi speed thành speed * 2 sau mỗi 10 giây
            speed += speed * 0.2f;
            Debug.Log("New Speed: " + speed);

        }
    }

}
