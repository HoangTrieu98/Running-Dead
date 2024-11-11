using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyFrefab;
    [SerializeField] private int enemyAmount;
    [SerializeField] Transform[] spawnPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            for (int i = 0; i < enemyAmount; i++)
            for (int j = 0; j < enemyFrefab.Length; j++)
            {
                    
                var randomPoint = spawnPosition[Random.Range(0, spawnPosition.Length)];
                var enemy = Instantiate(enemyFrefab[j], randomPoint.position, Quaternion.identity).GetComponent<Enemycontroll>();
                enemy.targetPlayer = other.transform.parent;
            }
        }
    }
}
