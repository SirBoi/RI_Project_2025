using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;

public class MainLoop : MonoBehaviour
{
    public GameObject agentPrefab;
    public Slider fpsSlider;

    private List<GameObject> agents = new List<GameObject>();

    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        GameObject agent = Instantiate(agentPrefab, Utility.GetGridPositionCenter(3, 4), Quaternion.identity);
        agents.Add(agent);

        fpsSlider.value = Application.targetFrameRate;
        fpsSlider.onValueChanged.AddListener(SetTargetFps);
    }

    // Update is called once per frame
    void Update()
    {
        counter++;

        if (counter >= 30)
        {
            int x = Random.Range(1, 9);
            int y = Random.Range(1, 9);
            Debug.Log(x + " " + y);

            agents[0].transform.position = Utility.GetGridPositionCenter(x, y);

            counter = 0;
        }

        Debug.Log("Target FPS set to: " + Application.targetFrameRate);
    }

    void InitializeSimulation(int numberOfTribes)
    {
        //InitializeTribes(numberOfTribes);
    }

    public void SetTargetFps(float newFps)
    {
        Application.targetFrameRate = Mathf.RoundToInt(newFps);
    }
}
