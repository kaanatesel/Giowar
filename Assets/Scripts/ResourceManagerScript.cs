using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManagerScript : MonoBehaviour
{
    //Public Variables
    //Private Variables
    private int gold;

    void Awake()
    {
        gold = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateGoldCount(int change)
    {
        gold += change;
        Debug.Log(gold);
    }
    public int getGold()
    {
        return gold;
    }
}
