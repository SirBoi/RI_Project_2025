using System.Collections.Generic;
using UnityEngine;

public class MainLoop : MonoBehaviour
{
    public GameObject agentPrefab;
    private UserInterface userInterfaceScript;
    private int counter = 0;
    private int totalTicks = 0;

    // Start is called before the first frame update
    void Start()
    {
        userInterfaceScript = GetComponent<UserInterface>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUserInterface();

        if (userInterfaceScript.isPaused)
            return;

        counter++;

        if (counter >= 120 / userInterfaceScript.fps)
        {
            ProcessAgents();
            ProcessTrees();
            ProcessHomes();

            totalTicks++;
            counter = 0;
        }
    }

    private void ProcessAgents()
    {
        for (int i = 0; i < InitScript.tribes.Count; i++)
        {
            List<GameObject> agentsToKill = new List<GameObject>();
            List<GameObject> agentsToProcess = new List<GameObject>();

            foreach (GameObject agentObject in InitScript.tribes[i])
                agentsToProcess.Add(agentObject);

            foreach (GameObject agentObject in agentsToProcess)
            {
                Agent agent = agentObject.GetComponent<Agent>();

                if (agent.ProcessDeath() != null)
                    agentsToKill.Add(agentObject);
                
                if (agent.isAdult)
                {
                    agent.ProcessAction();
                }

                agent.ProcessGrowth();
            }

            foreach (GameObject agentObject in agentsToProcess)
            {
                Agent agent = agentObject.GetComponent<Agent>();

                if (agent.isAdult)
                {
                    agent.ProcessReproduction();
                }
            }

            foreach (GameObject agentObject in agentsToKill)
            {
                InitScript.tribes[i].Remove(agentObject);
                Destroy(agentObject);
            }
        }
    }

    private void ProcessTrees()
    {
        foreach (GameObject tree in InitScript.trees)
            tree.GetComponent<Tree>().ProcessTree();
    }

    private void ProcessHomes()
    {
        foreach (GameObject home in InitScript.homes)
            home.GetComponent<Home>().ProcessHome();
    }

    private void UpdateUserInterface()
    {
        userInterfaceScript.UpdateTribeScores();
        userInterfaceScript.UpdateTribePopulation();
        userInterfaceScript.UpdateSimulationTicksCount(totalTicks);
        userInterfaceScript.UpdataSelectedObjectData();
    }
}
