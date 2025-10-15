using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    private bool isAdult;
    private int age;
    private int adulthoodAge;
    private int energy;
    private float inventory;
    private float inventoryCapacity;
    private float fertility;
    private float mutationRate;
    private float mutationStrength;
    private float vitality;
    private float speed;
    private float height;
    private float strength;
    private float vision;
    private float aggression;
    private float cowardice;
    private float charisma;
    private float curiosity;
    private float patience;

    // Awake is called during object initialization
    private void Awake()
    {
        InitializeAgent();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeAgent()
    {

    }
}
