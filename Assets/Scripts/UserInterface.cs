using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public Slider fpsSlider;
    public Button pauseButton;
    public Text scoreTribe1;
    public Text scoreTribe2;
    public Text scoreTribe3;
    public Text scoreTribe4;
    public Text populationTribe1;
    public Text populationTribe2;
    public Text populationTribe3;
    public Text populationTribe4;
    public Text simulationTicks;
    public int fps = 10;
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        fpsSlider.value = 10;
        fpsSlider.onValueChanged.AddListener(SetTargetFps);
        pauseButton.onClick.AddListener(PauseButtonPress);
    }

    public void UpdateTribeScores()
    {
        if (InitScript.homes.Count >= 1)
            scoreTribe1.text = "Tribe 1 prosperity: " + InitScript.homes[0].GetComponent<Home>().prosperity.ToString("F2");
        if (InitScript.homes.Count >= 2)
            scoreTribe2.text = "Tribe 2 prosperity: " + InitScript.homes[1].GetComponent<Home>().prosperity.ToString("F2");
        if (InitScript.homes.Count >= 3)
            scoreTribe3.text = "Tribe 3 prosperity: " + InitScript.homes[2].GetComponent<Home>().prosperity.ToString("F2");
        if (InitScript.homes.Count >= 4)
            scoreTribe4.text = "Tribe 4 prosperity: " + InitScript.homes[3].GetComponent<Home>().prosperity.ToString("F2");
    }
    public void UpdateTribePopulation()
    {
        if (InitScript.homes.Count >= 1)
            populationTribe1.text = "Tribe 1 population size: " + InitScript.tribes[0].Count;
        if (InitScript.homes.Count >= 2)
            populationTribe2.text = "Tribe 2 population size: " + InitScript.tribes[1].Count;
        if (InitScript.homes.Count >= 3)
            populationTribe3.text = "Tribe 3 population size: " + InitScript.tribes[2].Count;
        if (InitScript.homes.Count >= 4)
            populationTribe4.text = "Tribe 4 population size: " + InitScript.tribes[3].Count;
    }

    public void UpdateSimulationTicksCount(int ticksCount)
    {
        simulationTicks.text = "Simulation ticks: " + ticksCount.ToString();
    }

    public void SetTargetFps(float newFps)
    {
        fps = Mathf.RoundToInt(newFps);
    }

    public void PauseButtonPress()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseButton.GetComponentInChildren<Text>().text = "Pause";
        } else
        {
            isPaused = true;
            pauseButton.GetComponentInChildren<Text>().text = "Resume";
        }
    }
}
