using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tribe : MonoBehaviour
{
    private int id { get; }

    public Tribe(int id, int numberOfAgentsPerTribe)
    {
        this.id = id;

        for (int i = 0; i < numberOfAgentsPerTribe; i++)
        {
            Debug.Log(string.Format("Creating agent {0} of tribe {1}.", i, id));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
