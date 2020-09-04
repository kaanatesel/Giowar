using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseScript : MonoBehaviour, IselectAble, IcanHaveRoad
{
    // Public Variables
    //Private Variables
    private bool active;
    public RoadScript road;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            Debug.Log("house is active");
        }
        else
        {
        }
    }
    public bool isSelected()
    {
        return active;
    }

    public void setSelect(bool boolean)
    {
        active = boolean;
    }

    public void addRoad(RoadScript roadScript)
    {
        road = roadScript;
    }

    public RoadScript getRoad()
    {
        return road;
    }
    public int getRoadCount()
    {
        if (road == null)
            return 0;
        else
            return 1;
    }
}
