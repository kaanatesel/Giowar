using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseScript : MonoBehaviour, IselectAble, IcanHaveRoad, IBuyAble
{
    // Public Variables
    public RoadScript road;
    //Private Variables
    private bool active;
    private Color hightLightColor;
    private Color orginalColor;
    // Price
    private static int goldPrice =  4;
    private int minaralPrice = 4;

    void Awake()
    {
        hightLightColor = new Color(91f/255, 186f/255, 202f/255);
        SpriteRenderer spriteRenderer = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        orginalColor = spriteRenderer.material.color;
    }

    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer spriteRenderer = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        if (active)
        {
            spriteRenderer.material.color = hightLightColor;
        }
        else
        {
            spriteRenderer.material.color = orginalColor;
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
    public int getGoldPrice()
    {
        return goldPrice;
    }

    public int getMinaralPrice()
    {
        return minaralPrice;
    }
}
