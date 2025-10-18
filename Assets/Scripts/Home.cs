using UnityEngine;

public class Home : MonoBehaviour
{
    public int tribeId;
    public int x;
    public int y;
    private int counter = 0;
    public float prosperity = 0;
    public float maxProsperity = 0;
    public float storedFood = 0;
    public float ambition;

    // Start is called before the first frame update
    void Start()
    {
        ambition = InitScript.ambition;

        if (ambition <= 0) ambition = 1;
        if (ambition > 100) ambition = 100;
    }

    public void ProcessHome()
    {
        // Decay prosperity
        prosperity -= Mathf.Max(prosperity / 100, 0.01f);
        if (prosperity < 0) prosperity = 0;

        // Generate prosperity from excess food
        if (storedFood > 100 - ambition)
        {
            if (counter > 100) // Check if food supply is stable
            {
                prosperity += storedFood - 100 + ambition;
                maxProsperity = Mathf.Max(maxProsperity, prosperity);
                storedFood = 100 - ambition;
                counter = 0;
            } else
            {
                counter++;
            }
            
        } else
        {
            counter = 0;
        }
    }


}
