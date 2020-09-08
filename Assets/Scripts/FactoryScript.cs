
using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryScript : MonoBehaviour , IselectAble, IcanHaveRoad, IBuyAble
{
    // Public Variables
    // Private Varibales
    private bool active;
    private RoadScript road;
    private Color hightLightColor;
    private Color orginalColor;
    // Prive
    private static int goldPrice = 5;
    private static int minaralPrice = 11;


    void Awake()
    {
        hightLightColor = new Color(202f / 255, 202f / 255, 83f / 255);
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
