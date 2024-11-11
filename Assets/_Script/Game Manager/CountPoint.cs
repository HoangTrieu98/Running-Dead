using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountPoint : MonoBehaviour
{
    [SerializeField] private static int score = 0;

    public static void AddScore(int amount)
    {
        score += amount;
    }

    public int GetPoint()
    {
        return score;
    }
}
