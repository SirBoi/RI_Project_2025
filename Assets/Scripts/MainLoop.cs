using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class MainLoop : MonoBehaviour
{
    public Utility utility;
    public GameObject agentPrefab;

    private List<GameObject> agents = new List<GameObject>();

    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        GameObject agent = Instantiate(agentPrefab, utility.GetGridPosition(3, 4), Quaternion.identity);
        agents.Add(agent);
    }

    // Update is called once per frame
    void Update()
    {
        counter++;

        if (counter >= 60)
        {
            int x = Random.Range(1, 9);
            int y = Random.Range(1, 9);
            Debug.Log(x + " " + y);

            agents[0].transform.position = utility.GetGridPosition(x, y);

            counter = 0;
        }
    }
}
