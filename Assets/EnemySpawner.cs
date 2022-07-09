using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public float spawnRadius = 7f, time = 5;
    public GameObject[] enemies;
    public GameObject troop;
    public Transform target;
    public int waves = 0;
    void Start()
    {
        StartCoroutine(SpawnAnEnemy());

    }

    IEnumerator SpawnAnEnemy()
    {
        for(int i = 0;i <= waves / 160; i++) // every 160 waves will result in +1 spawn emission.
        {
            Vector2 spawnPos = target.transform.position;
            spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            if (enemy == troop)
            {
                for (int unit = 1; unit <= 6; unit++) Instantiate(enemy, spawnPos + Random.insideUnitCircle.normalized, Quaternion.identity);

            }
            else Instantiate(enemy, spawnPos, Quaternion.identity);
        }
        waves += 1;
        time = Mathf.Exp(1 / waves) - 0.5f;
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }
}
