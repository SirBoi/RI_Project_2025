using System.Collections.Generic;
using UnityEngine;

public class InitScript : MonoBehaviour
{
    public static List<GameObject> homes;
    public static List<List<GameObject>> tribes;
    public static List<GameObject> trees;
    public static int numberOfTribes;
    public static int numberOfAgentsPerTribe;
    public static int numberOfTrees;
    public static int fruitGrowthSpeed;
    public static float fruitNutrition;
    public static float fruitWeight;
    public static float ambition;
    public static float foodPerBirth;

    public GameObject homePrefab;
    public GameObject agentPrefab;
    public GameObject treePrefab;
    public int numberOfTribesVar;
    public int numberOfAgentsPerTribeVar;
    public int numberOfTreesVar;
    public int fruitGrowthSpeedVar;
    public float fruitNutritionVar;
    public float fruitWeightVar;
    public float ambitionVar;
    public float foodPerBirthVar;

    private void Awake()
    {
        Application.targetFrameRate = 120;

        homes = new List<GameObject>();
        tribes = new List<List<GameObject>>();
        trees = new List<GameObject>();
        numberOfTribes = numberOfTribesVar;
        numberOfAgentsPerTribe = numberOfAgentsPerTribeVar;
        numberOfTrees = numberOfTreesVar;
        fruitGrowthSpeed = fruitGrowthSpeedVar;
        fruitNutrition = fruitNutritionVar;
        fruitWeight = fruitWeightVar;
        ambition = ambitionVar;
}

    // Start is called before the first frame update
    void Start()
    {
        GenerateHomes();
        GenerateTrees();
        GenerateAgents();
    }

    private void GenerateHomes()
    {
        if (numberOfTribes == 1)
        {
            GameObject home1 = Instantiate(homePrefab, Utility.GetGridPositionCenter(0, 0), homePrefab.transform.rotation);
            home1.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(1);
            homes.Add(home1);
            tribes.Add(new List<GameObject>());
        }
        else if (numberOfTribes == 2)
        {
            GameObject home1 = Instantiate(homePrefab, Utility.GetGridPositionCenter(0, 0), homePrefab.transform.rotation);
            home1.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(1);
            homes.Add(home1);
            tribes.Add(new List<GameObject>());
            GameObject home2 = Instantiate(homePrefab, Utility.GetGridPositionCenter(9, 9), homePrefab.transform.rotation);
            home2.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(2);
            homes.Add(home2);
            tribes.Add(new List<GameObject>());
        }
        else if (numberOfTribes == 3)
        {
            GameObject home1 = Instantiate(homePrefab, Utility.GetGridPositionCenter(0, 0), homePrefab.transform.rotation);
            home1.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(1);
            homes.Add(home1);
            tribes.Add(new List<GameObject>());
            GameObject home2 = Instantiate(homePrefab, Utility.GetGridPositionCenter(9, 3), homePrefab.transform.rotation);
            home2.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(2);
            homes.Add(home2);
            tribes.Add(new List<GameObject>());
            GameObject home3 = Instantiate(homePrefab, Utility.GetGridPositionCenter(3, 9), homePrefab.transform.rotation);
            home3.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(3);
            homes.Add(home3);
            tribes.Add(new List<GameObject>());
        }
        else if (numberOfTribes == 4)
        {
            GameObject home1 = Instantiate(homePrefab, Utility.GetGridPositionCenter(0, 0), homePrefab.transform.rotation);
            home1.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(1);
            homes.Add(home1);
            tribes.Add(new List<GameObject>());
            GameObject home2 = Instantiate(homePrefab, Utility.GetGridPositionCenter(9, 0), homePrefab.transform.rotation);
            home2.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(2);
            homes.Add(home2);
            tribes.Add(new List<GameObject>());
            GameObject home3 = Instantiate(homePrefab, Utility.GetGridPositionCenter(0, 9), homePrefab.transform.rotation);
            home3.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(3);
            homes.Add(home3);
            tribes.Add(new List<GameObject>());
            GameObject home4 = Instantiate(homePrefab, Utility.GetGridPositionCenter(9, 9), homePrefab.transform.rotation);
            home4.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(4);
            homes.Add(home4);
            tribes.Add(new List<GameObject>());
        }
    }

    private void GenerateTrees()
    {
        List<(int, int)> treePositions = new List<(int, int)>();

        while (treePositions.Count < numberOfTrees)
        {
            int x = Random.Range(0, 10);
            int y = Random.Range(0, 10);
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

    private void GenerateAgents()
    {
        for (int i = 0; i < tribes.Count; i++)
        {
            for (int j = 0; j < numberOfAgentsPerTribe; j++)
            {
                GameObject agent = Instantiate(agentPrefab, Utility.GetGridPositionCenter(0, 0), agentPrefab.transform.rotation);
                agent.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(i+1);
                agent.GetComponent<Agent>().tribeId = i+1;
                tribes[i].Add(agent);
            }
        }
    }
}
