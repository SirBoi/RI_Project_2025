using UnityEngine;

public class Tree : MonoBehaviour
{
    private GameObject fruit;
    public int x;
    public int y;
    public int counter = 0;
    public bool isGrown = true;

    // Start is called before the first frame update
    void Start()
    {
        fruit = transform.Find("Fruit").gameObject;
    }

    public void ProcessTree()
    {
        if (!isGrown)
        {
            fruit.SetActive(false);
            counter++;
        }

        if (counter >= InitScript.fruitGrowthSpeed)
        {
            fruit.SetActive(true);
            counter = 0;
            isGrown = true;
        }
    }
}
