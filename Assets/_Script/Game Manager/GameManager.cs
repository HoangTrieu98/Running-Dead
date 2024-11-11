using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Point")]
    [SerializeField] CountPoint countPoint;
    [SerializeField] Text pointText;
    [SerializeField] private int point;

    [Header("Distance")]
    [SerializeField] CalculateDistance calculateDistance;
    [SerializeField] Text totalDistanceText;
    [SerializeField] private float totalDistance;

    void Start()
    {
        
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        PrintTotallDistance();
        PrintPoint();
    }

    void PrintTotallDistance()
    {
        totalDistance = calculateDistance.GetTotalDistance();
        totalDistanceText.text = ((int)totalDistance).ToString();
       
    }

    public void PrintPoint()
    {
        point = countPoint.GetPoint();
        pointText.text = point.ToString();
    }

 
}
