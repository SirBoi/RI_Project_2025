using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public GameObject agentPrefab;
    public int tribeId;
    public int x;
    public int y;
    public string status = "hungry";
    public (int, int) target;
    public bool isAdult = false;
    public int adulthoodAge;
    public int age = 0;
    public float energy = 0;
    public float inventory = 0;
    public float inventoryCapacity;
    public float fertility;
    public float mutationRate;
    public float mutationStrength;
    public float speed;
    public float height;
    public float strength;
    public float aggression;
    public float cowardice;
    public float charisma;
    public float patience;
    public int waitingTime = 0;
    public int birthCooldown = 0;

    public Agent ProcessDeath()
    {
        float mortality = Mathf.Floor(age / 100);
        int deathChance = (int)(1 / Mathf.Pow(10, mortality - 10));

        if (Random.Range(0, deathChance) == 0)
        {
            Debug.Log("Agent died at age " + age);
            return this;
        }
        return null;
    }

    public void ProcessFeeding()
    {
        Home home = InitScript.homes[tribeId - 1].GetComponent<Home>();

        if (isAdult && Utility.IsAtHome(x, y, tribeId) && energy == 0 && home.storedFood > 1)
        {
            home.storedFood -= 1;
            energy += 300;
        }
    }

    public void ProcessReproduction()
    {
        Home home = InitScript.homes[tribeId-1].GetComponent<Home>();

        if (isAdult && Utility.IsAtHome(x, y, tribeId) && home.storedFood > InitScript.foodPerBirth * fertility / 100 && birthCooldown <= 0 && Random.Range(0, 100) <= (100 / InitScript.tribes[tribeId - 1].Count * InitScript.numberOfAgentsPerTribe))
        {
            if (Random.Range(0, 100) <= fertility)
            {
                // Reproduction successfull
                GameObject newAgent = Instantiate(agentPrefab, Utility.GetAgentGridPosition(x, y, tribeId), agentPrefab.transform.rotation);
                newAgent.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(tribeId);
                newAgent.GetComponent<Agent>().GenerateGenes(this);
                InitScript.tribes[tribeId - 1].Add(newAgent);
                birthCooldown = InitScript.birthCooldown;
            }

            home.storedFood -= InitScript.foodPerBirth * fertility / 100;
        }

        birthCooldown--;
    }

    public void ProcessAction()
    {
        if (isAdult)
        {
            List<GameObject> homes = Utility.GetHomesAt(x, y);
            List<GameObject> agents = Utility.GetAgentsAt(x, y);
            List<GameObject> trees = Utility.GetTreesAt(x, y);

            PerformAction(homes, agents, trees);
        }
    }

    public void ProcessGrowth()
    {
        age++;

        if (age >= adulthoodAge)
            isAdult = true;
    }

    private void GenerateGenes(Agent parent)
    {
        // Copied genes
        tribeId = parent.tribeId;
        x = parent.x;
        y = parent.y;
        status = "hungry";
        isAdult = false;
        age = 0;
        energy = 0;
        inventory = 0;
        waitingTime = 0;
        birthCooldown = 0;
        mutationRate = InitScript.mutationRate;
        mutationStrength = InitScript.mutationStrength;

        // Clamp copied gene values
        if (mutationRate < 1) mutationRate = 1;
        if (mutationRate > 99) mutationRate = 99;
        if (mutationStrength < 0) mutationStrength = 0;
        if (mutationStrength > 100) mutationStrength = 100;

        // Mutated genes
        adulthoodAge = Mathf.RoundToInt(Mathf.RoundToInt(Random.Range(0, 100 - mutationRate)) == 0 ? (parent.adulthoodAge * (100 + mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.adulthoodAge);
        fertility = Mathf.RoundToInt(Random.Range(0, 100 - mutationRate)) == 0 ? (parent.fertility * (100 + mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.fertility;
        speed = Mathf.RoundToInt(Random.Range(0, 100 - mutationRate)) == 0 ? (parent.speed * (100 + mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.speed;
        height = Mathf.RoundToInt(Random.Range(0, 100 - mutationRate)) == 0 ? (parent.height * (100 + mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.height;
        strength = Mathf.RoundToInt(Random.Range(0, 100 - mutationRate)) == 0 ? (parent.strength * (100 + mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.strength;
        aggression = Mathf.RoundToInt(Random.Range(0, 100 - mutationRate)) == 0 ? (parent.aggression * (100 + mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.aggression;
        cowardice = Mathf.RoundToInt(Random.Range(0, 100 - mutationRate)) == 0 ? (parent.cowardice * (100 + mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.cowardice;
        charisma = Mathf.RoundToInt(Random.Range(0, 100 - mutationRate)) == 0 ? (parent.charisma * (100 + mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.charisma;
        patience = Mathf.RoundToInt(Random.Range(0, 100 - mutationRate)) == 0 ? (parent.patience * (100 + mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.patience;

        // Clamp mutated gene values
        if (adulthoodAge < 0) adulthoodAge = 0;
        if (adulthoodAge > 500) adulthoodAge = 500;
        if (fertility < 0) fertility = 0;
        if (fertility > 100) fertility = 100;
        if (speed < 0) speed = 0;
        if (speed > 100) speed = 100;
        if (height < 0) height = 0;
        if (height > 100) height = 100;
        if (strength < 1) strength = 1;
        if (strength > 100) strength = 100;
        if (aggression < 1) aggression = 1;
        if (aggression > 100) aggression = 100;
        if (cowardice < 1) cowardice = 1;
        if (cowardice > 100) cowardice = 100;
        if (charisma < 1) charisma = 1;
        if (charisma > 100) charisma = 100;
        if (patience < 0) patience = 0;
        if (patience > 200) patience = 200;

        inventoryCapacity = InitScript.fruitWeight * (100 + height * 4) / 100;
    }

    public void PerformAction(List<GameObject> homes, List<GameObject> agents, List<GameObject> trees)
    {
        switch (status)
        {
            case "searching":
                if (energy <= 0)
                    status = "going home";
                else if (Utility.ContainsGrownTree(trees) && Utility.ContainsEnemyAgent(agents, tribeId) && Utility.IsTarget(x, y, target))
                    status = "fighting";
                else if (Utility.ContainsGrownTree(trees) && Utility.IsTarget(x, y, target))
                    status = "collecting";
                else if (trees.Count >= 1 && !Utility.ContainsGrownTree(trees) && Utility.IsTarget(x, y, target))
                    status = "waiting";
                else
                    MoveTowardsTarget();
                break;

            case "going home":
                if (Utility.ContainsFriendlyHome(x, y, tribeId))
                {
                    Home h = InitScript.homes[tribeId - 1].GetComponent<Home>();
                    h.storedFood += inventory / InitScript.fruitWeight * InitScript.fruitNutrition;
                    inventory = 0;
                    if (energy <= InitScript.fruitNutrition / 4)
                        status = "hungry";
                    else
                    {
                        status = "searching";
                        SetTargetTree();
                    }
                }
                else
                    MoveTowardsHome();
                break;

            case "fighting":
                if (!trees[0].GetComponent<Tree>().isGrown)
                {
                    status = "searching";
                    SetTargetTree();
                }

                Agent opponent = agents[0].GetComponent<Agent>();

                float totalAggression = Random.Range(0, aggression) + Random.Range(0, opponent.aggression);
                float totalCowardice= Random.Range(0, cowardice) + Random.Range(0, opponent.cowardice);
                float totalCharisma= Random.Range(0, charisma) + Random.Range(0, opponent.charisma);

                if (totalAggression > totalCowardice && totalAggression > totalCharisma)
                {
                    if (Random.Range(0, strength) > Random.Range(0, opponent.strength))
                    {
                        status = "collecting";
                        opponent.status = "searching";
                        opponent.SetTargetTree();
                    }
                    else
                    {
                        opponent.status = "collecting";
                        status = "searching";
                        SetTargetTree();
                    }
                }
                else if (totalCowardice > totalCharisma)
                {
                    if (Random.Range(0, cowardice) - Random.Range(0, strength) > Random.Range(0, opponent.cowardice) - Random.Range(0, opponent.strength))
                    {
                        opponent.status = "collecting";
                        status = "searching";
                        SetTargetTree();
                    }
                    else
                    {
                        status = "collecting";
                        opponent.status = "searching";
                        opponent.SetTargetTree();
                    }
                }
                else
                {
                    trees[0].GetComponent<Tree>().isGrown = false;
                    inventory += InitScript.fruitWeight / 2;
                    opponent.inventory += InitScript.fruitWeight / 2;

                    if (inventory >= inventoryCapacity)
                        status = "going home";
                    else
                    {
                        status = "searching";
                        SetTargetTree();
                    }

                    if (opponent.inventory >= opponent.inventoryCapacity)
                        opponent.status = "going home";
                    else
                    {
                        opponent.status = "searching";
                        opponent.SetTargetTree();
                    }
                }
                break;

            case "collecting":
                trees[0].GetComponent<Tree>().isGrown = false;
                inventory += InitScript.fruitWeight;

                if (inventory >= inventoryCapacity)
                    status = "going home";
                else
                {
                    status = "searching";
                    SetTargetTree();
                }
                break;

            case "waiting":
                if (waitingTime > patience)
                {
                    status = "searching";
                    SetTargetTree();
                    waitingTime = 0;
                }
                else if (Utility.ContainsGrownTree(trees) && Utility.ContainsEnemyAgent(agents, tribeId))
                    status = "fighting";
                else if (Utility.ContainsGrownTree(trees) && !Utility.ContainsEnemyAgent(agents, tribeId))
                    status = "collecting";

                waitingTime++;
                break;

            case "hungry":
                Home home = InitScript.homes[tribeId - 1].GetComponent<Home>();

                if (home.storedFood >= 1)
                {
                    home.storedFood -= 1;
                    energy += 300;
                    status = "searching";
                    SetTargetTree();
                }
                break;
        }
    }

    public void SetTargetTree()
    {
        Tree selectedTree = InitScript.trees[Random.Range(0, InitScript.trees.Count)].GetComponent<Tree>();
        while (selectedTree.x == x && selectedTree.y == y)
            selectedTree = InitScript.trees[Random.Range(0, InitScript.trees.Count)].GetComponent<Tree>();

        target = (selectedTree.x, selectedTree.y);
    }

    private void MoveTowardsHome()
    {
        if (Random.Range(0, 100) <= speed)
        {
            Home home = InitScript.homes[tribeId - 1].GetComponent<Home>();

            (int, int) move = FindMoveTowards(home.x, home.y);

            Vector3 newPosition = Utility.GetAgentGridPosition(move.Item1, move.Item2, tribeId);
            transform.position = newPosition;
            x = move.Item1;
            y = move.Item2;
        }

        energy -= 1f + height / 100 + strength / 100 + speed / 200;

        if (Utility.IsAtHome(x, y, tribeId))
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        else
            gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    private void MoveTowardsTarget()
    {
        if (Random.Range(0, 100) <= speed)
        {
            (int, int) move = FindMoveTowards(target.Item1, target.Item2);

            Vector3 newPosition = Utility.GetAgentGridPosition(move.Item1, move.Item2, tribeId);
            transform.position = newPosition;
            x = move.Item1;
            y = move.Item2;
        }

        energy--;

        if (Utility.IsAtHome(x, y, tribeId))
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        else
            gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    private (int, int) FindMoveTowards(int xx, int yy)
    {
        (int, int) bestNeighbor = (x, y);
        float bestDistance = HexDistance((x, y), (xx, yy));
        List<(int, int)> directions = new List<(int, int)>() { (-1,0), (1,0), (0,-1), (0,1) };
        if (y % 2 == 0)
        {
            directions.Add((-1, -1));
            directions.Add((-1, 1));
        }
        else
        {
            directions.Add((1, -1));
            directions.Add((1, 1));
        }

        foreach (var dir in directions)
        {
            (int, int) neighbor = (x + dir.Item1, y + dir.Item2);
            float dist = HexDistance(neighbor, (xx, yy));
            if (dist < bestDistance && neighbor.Item1 >= 0 && neighbor.Item1 <= 9 && neighbor.Item2 >= 0 && neighbor.Item2 <= 9)
            {
                bestDistance = dist;
                bestNeighbor = neighbor;
            }
        }

        return bestNeighbor;
    }

    private float HexDistance((int, int) start, (int, int) end)
    {
        Vector3 startCoords = Utility.GetGridPositionCenter(start.Item1, start.Item2);
        Vector3 endCoords = Utility.GetGridPositionCenter(end.Item1, end.Item2);

        return Mathf.Pow(Mathf.Abs(startCoords.x - endCoords.x), 2) + Mathf.Pow(Mathf.Abs(startCoords.z - endCoords.z), 2);
    }
}
