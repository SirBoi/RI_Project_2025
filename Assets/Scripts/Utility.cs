using System;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static Material team1;
    public static Material team2;
    public static Material team3;
    public static Material team4;

    public Material team1Var;
    public Material team2Var;
    public Material team3Var;
    public Material team4Var;

    private void Awake()
    {
        team1 = team1Var;
        team2 = team2Var;
        team3 = team3Var;
        team4 = team4Var;
    }

    public static Vector3 GetGridPositionCenter(int x, int y)
    {
        return new Vector3(y % 2 == 0 ? x * 1.8f : 0.9f + x * 1.8f , 0, y * -1.55f);
    }

    public static Vector2 GetHexFromPosition(float x, float y, int tribeId)
    {
        int yy = Mathf.RoundToInt(Mathf.Abs(y + (tribeId <= 2 ? -0.5f : 0.5f)) / 1.55f);
        int xx = Mathf.RoundToInt(Mathf.Abs(x + (tribeId % 2 == 1 ? 0.5f : -0.5f) - (yy % 2 == 1 ? 0.9f : 0)) / 1.8f);

        return new Vector2(xx, yy);
    }

    public static Vector3 GetAgentGridPosition(int x, int y, int tribeId)
    {
        switch (tribeId)
        {
            case 1:
                return new Vector3(y % 2 == 0 ? x * 1.8f - 0.5f : 0.9f + x * 1.8f - 0.5f, 0.55f, y * -1.55f + 0.5f);
            case 2:
                return new Vector3(y % 2 == 0 ? x * 1.8f + 0.5f : 0.9f + x * 1.8f + 0.5f, 0.55f, y * -1.55f + 0.5f);
            case 3:
                return new Vector3(y % 2 == 0 ? x * 1.8f - 0.5f : 0.9f + x * 1.8f - 0.5f, 0.55f, y * -1.55f - 0.5f);
            case 4:
                return new Vector3(y % 2 == 0 ? x * 1.8f + 0.5f : 0.9f + x * 1.8f + 0.5f, 0.55f, y * -1.55f - 0.5f);
        }
        return new Vector3(y % 2 == 0 ? x * 1.8f : 0.9f + x * 1.8f, 0.55f, y * -1.55f);
    }

    public static Material GetTeamMaterial(int teamId)
    {
        switch (teamId)
        {
            case 1:
                return team1;
            case 2:
                return team2;
            case 3:
                return team3;
            case 4:
                return team4;
        }
        return null;
    }

    public static bool IsNearHome(int x, int y)
    {
        if (InitScript.numberOfTribes == 1)
        {
            if (DistanceBetween(x, y, 0, 0) <= 2) return true;
        }
        else if (InitScript.numberOfTribes == 2)
        {
            if (DistanceBetween(x, y, 0, 0) <= 2) return true;
            if (DistanceBetween(x, y, 9, 9) <= 2) return true;
        }
        else if (InitScript.numberOfTribes == 3)
        {
            if (DistanceBetween(x, y, 0, 0) <= 2) return true;
            if (DistanceBetween(x, y, 9, 3) <= 2) return true;
            if (DistanceBetween(x, y, 3, 9) <= 2) return true;
        }
        else if (InitScript.numberOfTribes == 4)
        {
            if (DistanceBetween(x, y, 0, 0) <= 2) return true;
            if (DistanceBetween(x, y, 9, 0) <= 2) return true;
            if (DistanceBetween(x, y, 0, 9) <= 2) return true;
            if (DistanceBetween(x, y, 9, 9) <= 2) return true;
        }
        return false;
    }

    public static int DistanceBetween(int x1, int y1, int x2, int y2)
    {
        return (int)Mathf.Max(
            Mathf.Abs(y2 - y1),
            Mathf.Abs(Mathf.Ceil(y2 / -2) + x2 - Mathf.Ceil(y1 / -2) - x1),
            Mathf.Abs(-y2 - Mathf.Ceil(y2 / -2) - x2 + y1 + Mathf.Ceil(y1 / -2) + x1));
    }

    public static bool IsAtHome(int x, int y, int tribeId)
    {
        if (InitScript.numberOfTribes == 1)
        {
            if (tribeId == 1 && x == 0 && y == 0) return true;
        }
        else if (InitScript.numberOfTribes == 2)
        {
            if (tribeId == 1 && x == 0 && y == 0) return true;
            if (tribeId == 2 && x == 9 && y == 9) return true;
        }
        else if (InitScript.numberOfTribes == 3)
        {
            if (tribeId == 1 && x == 0 && y == 0) return true;
            if (tribeId == 2 && x == 9 && y == 3) return true;
            if (tribeId == 3 && x == 3 && y == 9) return true;
        }
        else if (InitScript.numberOfTribes == 4)
        {
            if (tribeId == 1 && x == 0 && y == 0) return true;
            if (tribeId == 2 && x == 9 && y == 0) return true;
            if (tribeId == 3 && x == 0 && y == 9) return true;
            if (tribeId == 4 && x == 9 && y == 9) return true;
        }
        return false;
    }

    public static List<GameObject> GetHomesAt(int x, int y)
    {
        List<GameObject> foundHomes = new List<GameObject>();

        foreach (GameObject home in InitScript.homes)
        {
            Home h = home.GetComponent<Home>();

            if (h.x == x && h.y == y)
                foundHomes.Add(home);
        }

        return foundHomes;
    }

    public static List<GameObject> GetAgentsAt(int x, int y)
    {
        List<GameObject> foundAgents = new List<GameObject>();

        foreach (List<GameObject> tribe in InitScript.tribes)
        {
            foreach (GameObject agent in tribe)
            {
                Agent a = agent.GetComponent<Agent>();

                if (a.x == x && a.y == y)
                    foundAgents.Add(agent);
            }
        }

        return foundAgents;
    }

    public static List<GameObject> GetTreesAt(int x, int y)
    {
        List<GameObject> foundTrees = new List<GameObject>();

        foreach (GameObject tree in InitScript.trees)
        {
            Tree t = tree.GetComponent<Tree>();

            if (t.x == x && t.y == y)
                foundTrees.Add(tree);
        }

        return foundTrees;
    }

    public static bool ContainsGrownTree(List<GameObject> trees)
    {
        foreach(GameObject tree in trees)
        {
            if (tree.GetComponent<Tree>().isGrown)
                return true;
        }
        return false;
    }

    public static bool ContainsEnemyAgent(List<GameObject> agents, int tribeId)
    {
        foreach (GameObject agent in agents)
        {
            if (agent.GetComponent<Agent>().tribeId != tribeId)
                return true;
        }
        return false;
    }

    public static bool ContainsFriendlyHome(int x, int y, int tribeId)
    {
        Home home = InitScript.homes[tribeId - 1].GetComponent<Home>();
        
        if (home.x == x && home.y == y)
            return true;
        return false;
    }

    internal static bool IsTarget(int x, int y, (int, int) target)
    {
        return (x == target.Item1 && y == target.Item2);
    }
}
