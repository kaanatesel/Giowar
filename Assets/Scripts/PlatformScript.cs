﻿using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlatformScript : MonoBehaviour, IselectAble, IcanHaveRoad, IBuyAble
{
    //Public Variables
    //Private Variables
    private bool acvtive;
    private int connetedRoadCount;
    private const int maxRoadCapacity = 4;
    private List<RoadScript> roadList = new List<RoadScript>();
    //Draw Circle variables
    public float ThetaScale = 0.001f;
    public float radius = 1.5f;
    private int Size;
    private LineRenderer LineDrawer;
    private float Theta = 0f;
    private Color startColor, endColor;
    // Price
    private static int goldPrice = 2;
    private static int minaralPrice = 2;


    void Awake()
    {
        connetedRoadCount = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        acvtive = false;    
        //SpriteRenderer spriteRenderer = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        startColor = Color.green;
        endColor = Color.green;
        LineDrawer = GetComponent<LineRenderer>();
        LineDrawer.material = new Material(Shader.Find("Sprites/Default"));
        LineDrawer.startColor = startColor;
        LineDrawer.endColor = endColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (acvtive)
        {
            DrawCircle();
        }
        else
        {
            LineDrawer.positionCount = 0;
        }
    }
    
    private void DrawCircle()
    {
        Theta = 0f;
        Size = (int)((1f / ThetaScale) + 2f);
        LineDrawer.positionCount = Size;
        for (int i = 0; i < Size; i++)
        {
            Theta += (2.0f * Mathf.PI * ThetaScale);
            float x = radius * Mathf.Cos(Theta);
            float y = radius * Mathf.Sin(Theta);
            x += gameObject.transform.position.x;
            y += gameObject.transform.position.y;
            LineDrawer.SetPosition(i, new Vector3(x, y, 0));
        }
    }

    public void setSelect(bool boolean)
    {
        acvtive = boolean;
    }

    public bool isSelected()
    {
        return acvtive;
    }

    public bool canHaveMoreRoad()
    {
        return connetedRoadCount < maxRoadCapacity;
    }

    public void addRoad(RoadScript road)
    {
        roadList.Add(road);
        connetedRoadCount += 1;
    }

    public int getRoadCount()
    {
        return connetedRoadCount;
    }

    public RoadScript getRoad()
    {
        int rndInt = Random.Range(0, connetedRoadCount);
        return roadList[rndInt];
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
