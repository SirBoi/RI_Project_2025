using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresetLoader : MonoBehaviour
{
    public static void LoadPreset(Agent agent)
    {
        switch (agent.tribeId)
        {
            case 1:
                ValuesPreset1.Load(agent);
                break;
            case 2:
                ValuesPreset2.Load(agent);
                break;
            case 3:
                ValuesPreset3.Load(agent);
                break;
            case 4:
                ValuesPreset4.Load(agent);
                break;
        }
    }
}
