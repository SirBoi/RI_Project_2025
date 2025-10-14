using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public Vector3 GetGridPosition(int x, int y)
    {
        return new Vector3(y % 2 == 0 ? x * 1.8f : 0.9f + x * 1.8f , 0.55f, y * -1.55f);
    }
}
