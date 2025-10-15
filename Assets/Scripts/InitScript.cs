using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class InitScript : MonoBehaviour
{
    public GameObject homePrefab;
    public GameObject treePrefab;

    public List<GameObject> homes;
    public List<GameObject> trees;

    // Start is called before the first frame update
    void Start()
    {
        GenerateHomes();
        GenerateTrees();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateHomes()
    {
        if (Utility.numberOfTribes == 1)
        {
            GameObject home1 = Instantiate(homePrefab, Utility.GetGridPositionCenter(0, 0), homePrefab.transform.rotation);
            home1.GetComponent<MeshRenderer>().material = Utility.team1;
            homes.Add(home1);
        }
        else if (Utility.numberOfTribes == 2)
        {
            GameObject home1 = Instantiate(homePrefab, Utility.GetGridPositionCenter(0, 0), homePrefab.transform.rotation);
            home1.GetComponent<MeshRenderer>().material = Utility.team1;
            homes.Add(home1);
            GameObject home2 = Instantiate(homePrefab, Utility.GetGridPositionCenter(9, 9), homePrefab.transform.rotation);
            home2.GetComponent<MeshRenderer>().material = Utility.team2;
            homes.Add(home2);
        }
        else if (Utility.numberOfTribes == 3)
        {
            GameObject home1 = Instantiate(homePrefab, Utility.GetGridPositionCenter(0, 0), homePrefab.transform.rotation);
            home1.GetComponent<MeshRenderer>().material = Utility.team1;
            homes.Add(home1);
            GameObject home2 = Instantiate(homePrefab, Utility.GetGridPositionCenter(9, 3), homePrefab.transform.rotation);
            home2.GetComponent<MeshRenderer>().material = Utility.team2;
            homes.Add(home2);
            GameObject home3 = Instantiate(homePrefab, Utility.GetGridPositionCenter(3, 9), homePrefab.transform.rotation);
            home3.GetComponent<MeshRenderer>().material = Utility.team3;
            homes.Add(home3);
        }
        else if (Utility.numberOfTribes == 4)
        {
            GameObject home1 = Instantiate(homePrefab, Utility.GetGridPositionCenter(0, 0), homePrefab.transform.rotation);
            home1.GetComponent<MeshRenderer>().material = Utility.team1;
            homes.Add(home1);
            GameObject home2 = Instantiate(homePrefab, Utility.GetGridPositionCenter(9, 0), homePrefab.transform.rotation);
            home2.GetComponent<MeshRenderer>().material = Utility.team2;
            homes.Add(home2);
            GameObject home3 = Instantiate(homePrefab, Utility.GetGridPositionCenter(0, 9), homePrefab.transform.rotation);
            home3.GetComponent<MeshRenderer>().material = Utility.team3;
            homes.Add(home3);
            GameObject home4 = Instantiate(homePrefab, Utility.GetGridPositionCenter(9, 9), homePrefab.transform.rotation);
            home4.GetComponent<MeshRenderer>().material = Utility.team4;
            homes.Add(home4);
        }
    }

    private void GenerateTrees()
    {
        List<(int, int)> treePositions = new List<(int, int)>();

        while (treePositions.Count < Utility.numberOfTrees)
        {
            int x = UnityEngine.Random.Range(0, 10);
            int y = UnityEngine.Random.Range(0, 10);
            bool skip = false;
            
            if (!treePositions.Contains((x, y)) && !Utility.IsNearHome(x, y))
            {
                foreach ((int, int) position in treePositions)
                {
                    if (Utility.DistanceBetween(x, y, position.Item1, position.Item2) <= 2)
                        skip = true;
                }
                if (!skip)
                    treePositions.Add((x, y));
            }
        }
        foreach ((int, int) position in treePositions)
        {
            GameObject tree = Instantiate(treePrefab, Utility.GetGridPositionCenter(position.Item1, position.Item2) + new Vector3(0, 0.45f, 0), treePrefab.transform.rotation);
            trees.Add(tree);
        }
    }
}
