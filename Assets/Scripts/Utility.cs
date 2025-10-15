using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static int numberOfTribes;
    public static int numberOfAgentsPerTribe;
    public static int numberOfTrees;
    public static Material team1;
    public static Material team2;
    public static Material team3;
    public static Material team4;

    public int numberOfTribesVar;
    public int numberOfAgentsPerTribeVar;
    public int numberOfTreesVar;
    public Material team1Var;
    public Material team2Var;
    public Material team3Var;
    public Material team4Var;

    private void Awake()
    {
        numberOfTribes = numberOfTribesVar;
        numberOfAgentsPerTribe = numberOfAgentsPerTribeVar;
        numberOfTrees = numberOfTreesVar;
        team1 = team1Var;
        team2 = team2Var;
        team3 = team3Var;
        team4 = team4Var;
    }

    public static Vector3 GetGridPositionCenter(int x, int y)
    {
        return new Vector3(y % 2 == 0 ? x * 1.8f : 0.9f + x * 1.8f , 0, y * -1.55f);
    }

    public static bool IsNearHome(int x, int y)
    {
        if (Utility.numberOfTribes == 1)
        {
            if (DistanceBetween(x, y, 0, 0) <= 2) return true;
        }
        else if (Utility.numberOfTribes == 2)
        {
            if (DistanceBetween(x, y, 0, 0) <= 2) return true;
            if (DistanceBetween(x, y, 9, 9) <= 2) return true;
        }
        else if (Utility.numberOfTribes == 3)
        {
            if (DistanceBetween(x, y, 0, 0) <= 2) return true;
            if (DistanceBetween(x, y, 9, 3) <= 2) return true;
            if (DistanceBetween(x, y, 3, 9) <= 2) return true;
        }
        else if (Utility.numberOfTribes == 4)
        {
            if (DistanceBetween(x, y, 0, 0) <= 2) return true;
            if (DistanceBetween(x, y, 9, 0) <= 2) return true;
            if (DistanceBetween(x, y, 0, 9) <= 2) return true;
            if (DistanceBetween(x, y, 9, 9) <= 2) return true;
        }
        return false;
    }

    public static int DistanceBetween(int x1, int y1, int x2, int y2)
    {
        return (int)Mathf.Max(
            Mathf.Abs(y2 - y1),
            Mathf.Abs(Mathf.Ceil(y2 / -2) + x2 - Mathf.Ceil(y1 / -2) - x1),
            Mathf.Abs(-y2 - Mathf.Ceil(y2 / -2) - x2 + y1 + Mathf.Ceil(y1 / -2) + x1));
    }
}
