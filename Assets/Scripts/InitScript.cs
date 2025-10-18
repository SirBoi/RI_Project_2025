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
    public static int birthCooldown;
    public static float mutationRate;
    public static float mutationStrength;

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
    public int birthCooldownVar;
    public float mutationRateVar;
    public float mutationStrengthVar;

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
        foodPerBirth = foodPerBirthVar;
        birthCooldown = birthCooldownVar;
        mutationRate = mutationRateVar;
        mutationStrength = mutationStrengthVar;
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
            home1.GetComponent<Home>().tribeId = 1;
            home1.GetComponent<Home>().x = 0;
            home1.GetComponent<Home>().y = 0;
            home1.GetComponent<Home>().storedFood = numberOfAgentsPerTribe;
            homes.Add(home1);
            tribes.Add(new List<GameObject>());
        }
        else if (numberOfTribes == 2)
        {
            GameObject home1 = Instantiate(homePrefab, Utility.GetGridPositionCenter(0, 0), homePrefab.transform.rotation);
            home1.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(1);
            home1.GetComponent<Home>().tribeId = 1;
            home1.GetComponent<Home>().x = 0;
            home1.GetComponent<Home>().y = 0;
            home1.GetComponent<Home>().storedFood = numberOfAgentsPerTribe;
            homes.Add(home1);
            tribes.Add(new List<GameObject>());
            GameObject home2 = Instantiate(homePrefab, Utility.GetGridPositionCenter(9, 9), homePrefab.transform.rotation);
            home2.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(2);
            home2.GetComponent<Home>().tribeId = 2;
            home2.GetComponent<Home>().x = 9;
            home2.GetComponent<Home>().y = 9;
            home2.GetComponent<Home>().storedFood = numberOfAgentsPerTribe;
            homes.Add(home2);
            tribes.Add(new List<GameObject>());
        }
        else if (numberOfTribes == 3)
        {
            GameObject home1 = Instantiate(homePrefab, Utility.GetGridPositionCenter(0, 0), homePrefab.transform.rotation);
            home1.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(1);
            home1.GetComponent<Home>().tribeId = 1;
            home1.GetComponent<Home>().x = 0;
            home1.GetComponent<Home>().y = 0;
            home1.GetComponent<Home>().storedFood = numberOfAgentsPerTribe;
            homes.Add(home1);
            tribes.Add(new List<GameObject>());
            GameObject home2 = Instantiate(homePrefab, Utility.GetGridPositionCenter(9, 3), homePrefab.transform.rotation);
            home2.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(2);
            home2.GetComponent<Home>().tribeId = 2;
            home2.GetComponent<Home>().x = 9;
            home2.GetComponent<Home>().y = 3;
            home2.GetComponent<Home>().storedFood = numberOfAgentsPerTribe;
            homes.Add(home2);
            tribes.Add(new List<GameObject>());
            GameObject home3 = Instantiate(homePrefab, Utility.GetGridPositionCenter(3, 9), homePrefab.transform.rotation);
            home3.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(3);
            home3.GetComponent<Home>().tribeId = 3;
            home3.GetComponent<Home>().x = 3;
            home3.GetComponent<Home>().y = 9;
            home3.GetComponent<Home>().storedFood = numberOfAgentsPerTribe;
            homes.Add(home3);
            tribes.Add(new List<GameObject>());
        }
        else if (numberOfTribes == 4)
        {
            GameObject home1 = Instantiate(homePrefab, Utility.GetGridPositionCenter(0, 0), homePrefab.transform.rotation);
            home1.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(1);
            home1.GetComponent<Home>().tribeId = 1;
            home1.GetComponent<Home>().x = 0;
            home1.GetComponent<Home>().y = 0;
            home1.GetComponent<Home>().storedFood = numberOfAgentsPerTribe;
            homes.Add(home1);
            tribes.Add(new List<GameObject>());
            GameObject home2 = Instantiate(homePrefab, Utility.GetGridPositionCenter(9, 0), homePrefab.transform.rotation);
            home2.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(2);
            home2.GetComponent<Home>().tribeId = 2;
            home2.GetComponent<Home>().x = 9;
            home2.GetComponent<Home>().y = 0;
            home2.GetComponent<Home>().storedFood = numberOfAgentsPerTribe;
            homes.Add(home2);
            tribes.Add(new List<GameObject>());
            GameObject home3 = Instantiate(homePrefab, Utility.GetGridPositionCenter(0, 9), homePrefab.transform.rotation);
            home3.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(3);
            home3.GetComponent<Home>().tribeId = 3;
            home3.GetComponent<Home>().x = 0;
            home3.GetComponent<Home>().y = 9;
            home3.GetComponent<Home>().storedFood = numberOfAgentsPerTribe;
            homes.Add(home3);
            tribes.Add(new List<GameObject>());
            GameObject home4 = Instantiate(homePrefab, Utility.GetGridPositionCenter(9, 9), homePrefab.transform.rotation);
            home4.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(4);
            home4.GetComponent<Home>().tribeId = 4;
            home4.GetComponent<Home>().x = 9;
            home4.GetComponent<Home>().y = 9;
            home4.GetComponent<Home>().storedFood = numberOfAgentsPerTribe;
            homes.Add(home4);
            tribes.Add(new List<GameObject>());
        }
    }

    private void GenerateTrees()
    {
        int noTries = 0;
        List<(int, int)> treePositions = new List<(int, int)>();

        while (treePositions.Count < numberOfTrees)
        {
            if (noTries > 2000)
            {
                treePositions.Clear();
                noTries = 0;
            }

            int x = Random.Range(0, 10);
            int y = Random.Range(0, 10);
            bool skip = false;
            
            if (!treePositions.Contains((x, y)) && !Utility.IsNearHome(x, y))
            {
                foreach ((int, int) position in treePositions)
                {
                    if (Utility.DistanceBetween(x, y, position.Item1, position.Item2) <= 1)
                        skip = true;
                }
                if (!skip)
                    treePositions.Add((x, y));
            }
            noTries++;
        }
        foreach ((int, int) position in treePositions)
        {
            GameObject tree = Instantiate(treePrefab, Utility.GetGridPositionCenter(position.Item1, position.Item2) + new Vector3(0, 0.45f, 0), treePrefab.transform.rotation);
            tree.GetComponent<Tree>().x = position.Item1;
            tree.GetComponent<Tree>().y = position.Item2;
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
                Agent a = agent.GetComponent<Agent>();
                agent.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(i+1);
                a.tribeId = i+1;
                a.x = homes[i].GetComponent<Home>().x;
                a.y = homes[i].GetComponent<Home>().y;
                a.mutationRate = mutationRate;
                a.mutationStrength = mutationStrength;
                a.isAdult = true;

                if (a.mutationRate < 1) a.mutationRate = 1;
                if (a.mutationRate > 99) a.mutationRate = 99;
                if (a.mutationStrength < 0) a.mutationStrength = 0;
                if (a.mutationStrength > 100) a.mutationStrength = 100;

                PresetLoader.LoadPreset(a);
                a.inventoryCapacity = fruitWeight * (100 + a.height * 4) / 100;

                tribes[i].Add(agent);
            }
        }
    }
}
