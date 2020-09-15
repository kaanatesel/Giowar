using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour, IselectAble, IcanHaveRoad, IBuyAble
{
    //Public Variables
    //Private Variables
    private bool active;
    private RoadScript road;
    // Price
    private static int goldPrice = 8;
    private int minaralPrice = 10;
    //Draw Circle variables
    public float ThetaScale = 0.001f;
    public float radius = 4f;
    private int Size;
    private LineRenderer LineDrawer;
    private float Theta = 0f;
    private Color startColor, endColor;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        startColor = Color.black;
        endColor = Color.black;
        LineDrawer = GetComponent<LineRenderer>();
        LineDrawer.material = new Material(Shader.Find("Sprites/Default"));
        LineDrawer.startColor = startColor;
        LineDrawer.endColor = endColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            DrawCircle();
        }
        else
        {
            LineDrawer.positionCount = 0;
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
        return (road == null) ? 0 : 1;
    }

    public int getGoldPrice()
    {
        return goldPrice;
    }

    public int getMinaralPrice()
    {
        return minaralPrice;
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
}
