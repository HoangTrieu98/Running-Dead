using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public RoadSpawner roadSpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
        
    }
    public void SpawnTriggerEntered()
    {
        roadSpawner.MoveRoad();
    }
}
