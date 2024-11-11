using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxTrigger : MonoBehaviour
{
    [SerializeField] private GameObject lootboxPrefab;
    [SerializeField] private Transform[] spawnPosition;


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LootBoxSpawn();
        }
        
    }

    void LootBoxSpawn()
    {
        for (int i = 0; i < spawnPosition.Length; i++)
        {
            Instantiate(lootboxPrefab, spawnPosition[i].position, Quaternion.identity);
        }
    }
}
