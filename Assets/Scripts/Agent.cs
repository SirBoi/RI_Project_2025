using UnityEngine;

public class Agent : MonoBehaviour
{
    public GameObject agentPrefab;
    public int tribeId;
    public int x;
    public int y;
    public bool isAdult;
    public int age;
    public int adulthoodAge;
    public float energy;
    public float inventory;
    public float inventoryCapacity;
    public float fertility;
    public float mutationRate;
    public float mutationStrength;
    public float vitality;
    public float speed;
    public float height;
    public float strength;
    public float vision;
    public float aggression;
    public float cowardice;
    public float charisma;
    public float curiosity;
    public float patience;

    // Dodaj age efekat svagdje

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
            energy += InitScript.fruitNutrition;
        }
    }

    public void ProcessReproduction()
    {
        Home home = InitScript.homes[tribeId-1].GetComponent<Home>();

        if (isAdult && Utility.IsAtHome(x, y, tribeId) && home.storedFood > InitScript.foodPerBirth / fertility)
        {
            if (Random.Range(0, fertility) == 0)
            {
                // Reproduction successfull
                GameObject newAgent = Instantiate(agentPrefab, Utility.GetAgentGridPosition(x, y, tribeId), agentPrefab.transform.rotation);
                newAgent.GetComponent<MeshRenderer>().material = Utility.GetTeamMaterial(tribeId);
                newAgent.GetComponent<Agent>().GenerateGenes(this);
                InitScript.tribes[tribeId-1].Add(newAgent);
            }
            
            home.storedFood -= InitScript.foodPerBirth;
        }
    }

    public void ProcessAction()
    {
        if (isAdult)
        {
            int newX = Random.Range(0, 10);
            int newY = Random.Range(0, 10);

            Vector3 newPosition = Utility.GetAgentGridPosition(newX, newY, tribeId);
            transform.position = newPosition;
            x = newX;
            y = newY;

            if (Utility.IsAtHome(x, y, tribeId))
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            else
                gameObject.GetComponent<MeshRenderer>().enabled = true;
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
        isAdult = false;
        age = 0;
        energy = 0;
        inventory = 0;
        mutationRate = parent.mutationRate;
        mutationStrength = parent.mutationStrength;

        // Mutated genes
        adulthoodAge = Mathf.RoundToInt(Random.Range(0, 100 - parent.mutationRate) == 0 ? (parent.adulthoodAge * (100 + parent.mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.adulthoodAge);
        fertility = Random.Range(0, 100 - parent.mutationRate) == 0 ? (parent.fertility * (100 + parent.mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.fertility;
        vitality = Random.Range(0, 100 - parent.mutationRate) == 0 ? (parent.vitality * (100 + parent.mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.vitality;
        speed = Random.Range(0, 100 - parent.mutationRate) == 0 ? (parent.speed * (100 + parent.mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.speed;
        height = Random.Range(0, 100 - parent.mutationRate) == 0 ? (parent.height * (100 + parent.mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.height;
        strength = Random.Range(0, 100 - parent.mutationRate) == 0 ? (parent.strength * (100 + parent.mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.strength;
        vision = Random.Range(0, 100 - parent.mutationRate) == 0 ? (parent.vision * (100 + parent.mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.vision;
        aggression = Random.Range(0, 100 - parent.mutationRate) == 0 ? (parent.aggression * (100 + parent.mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.aggression;
        cowardice = Random.Range(0, 100 - parent.mutationRate) == 0 ? (parent.cowardice * (100 + parent.mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.cowardice;
        charisma = Random.Range(0, 100 - parent.mutationRate) == 0 ? (parent.charisma * (100 + parent.mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.charisma;
        curiosity = Random.Range(0, 100 - parent.mutationRate) == 0 ? (parent.curiosity * (100 + parent.mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.curiosity;
        patience = Random.Range(0, 100 - parent.mutationRate) == 0 ? (parent.patience * (100 + parent.mutationStrength) / (Random.Range(0, 2) == 0 ? 100 : -100)) : parent.patience;

        // Clamp gene values
        if (adulthoodAge < 0) adulthoodAge = 0;
        if (adulthoodAge > 500) adulthoodAge = 500;
        if (fertility < 0) fertility = 0;
        if (fertility > 100) fertility = 100;
        if (vitality < 0) vitality = 0;
        if (speed < 0) speed = 0;
        if (height < 0) height = 0;
        if (strength < 0) strength = 0;
        if (vision < 0) vision = 0;
        if (aggression < 0) aggression = 0;
        if (cowardice < 0) cowardice = 0;
        if (charisma < 0) charisma = 0;
        if (curiosity < 0) curiosity = 0;
        if (patience < 0) patience = 0;

        inventoryCapacity = InitScript.fruitWeight * 2 * (100 + height) / 100;
    }
}
