 using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using static Spawner;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnChance;
    }
    public SpawnableObject[] objects;
    public float runTime=4f;
    public float respawnTime = 1.0f;
    public float minSpawnrate=1f;

    public float maxSpawnrate=6f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnrate, maxSpawnrate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
    private void Spawn()
    {
        float spawnChance = Random.value;

        foreach (var obj in objects)
        {
            if (spawnChance < obj.spawnChance)
            {
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }

            spawnChance -= obj.spawnChance; // Trừ đi spawnChance của obj hiện tại

            if (spawnChance <= 0f)
                break;
        }

        Invoke(nameof(Spawn), runTime);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 contactPoint = collision.bounds.center;

            // Kiểm tra nếu player va chạm từ trái hoặc phải
            if (contactPoint.x <= transform.position.x-1f || contactPoint.x >= transform.position.x-1f)
            {
                // Spawner chết
                Destroy(gameObject);
                FindObjectOfType<GameManager>().SpawnerDeath();

            }
            else
            {
                // Player chết
                Destroy(collision.gameObject);
                
            } 
        }
      
    }
  
     
    

}
