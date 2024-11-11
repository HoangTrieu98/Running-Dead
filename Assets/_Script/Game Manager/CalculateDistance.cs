using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDistance : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private Vector3 previousPosition;
    [SerializeField] private float totalDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        totalDistance = 0f;
        previousPosition = character.position;
    }

    // Update is called once per frame
    void Update()
    {
        Calculate();
    }

    public void Calculate()
    {

        float distanceMoved = Vector3.Distance(character.position, previousPosition);
        totalDistance += distanceMoved;
        previousPosition = character.position;
    }

    public float GetTotalDistance()
    {
        return totalDistance;
    }
}
