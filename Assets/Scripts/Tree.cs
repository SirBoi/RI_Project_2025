using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Tree : MonoBehaviour
{
    private GameObject fruit;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        fruit = transform.Find("Fruit").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        counter++;

        if (counter >= 30)
        {
            if (fruit.active)
                fruit.SetActive(false);
            else
                fruit.SetActive(true);

            counter = 0;
        }
    }
}
