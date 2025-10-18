using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValuesPreset4 : MonoBehaviour
{
    public int adulthoodAge;
    public float fertility;
    public float speed;
    public float height;
    public float strength;
    public float aggression;
    public float cowardice;
    public float charisma;
    public float patience;

    public static int adulthoodAgeVar;
    public static float fertilityVar;
    public static float speedVar;
    public static float heightVar;
    public static float strengthVar;
    public static float aggressionVar;
    public static float cowardiceVar;
    public static float charismaVar;
    public static float patienceVar;

    private void Awake()
    {
        adulthoodAgeVar = adulthoodAge;
        fertilityVar = fertility;
        speedVar = speed;
        heightVar = height;
        strengthVar = strength;
        aggressionVar = aggression;
        cowardiceVar = cowardice;
        charismaVar = charisma;
        patienceVar = patience;
    }

    public static void Load(Agent agent)
    {
        agent.adulthoodAge = adulthoodAgeVar;
        agent.fertility = fertilityVar;
        agent.speed = speedVar;
        agent.height = heightVar;
        agent.strength = strengthVar;
        agent.aggression = aggressionVar;
        agent.cowardice = cowardiceVar;
        agent.charisma = charismaVar;
        agent.patience = patienceVar;
    }
}
