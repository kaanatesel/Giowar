using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaralScript : MonoBehaviour, IselectAble
{
    //Public Variables
    public GameObject road;    
    //Private Variables
    private bool active;
    private bool isBuildState;
    private MineScript mine;
    private RoadScript mineRoad;
    //Draw Circle variables
    public float ThetaScale = 0.001f;
    public float radius = 1.5f;
    private int Size;
    private LineRenderer LineDrawer;
    private float Theta = 0f;
    private Color startColor, endColor;

    void Awake()
    {
        active = false;
        isBuildState = false;

        SpriteRenderer spriteRenderer = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        startColor = Color.red;
        endColor = Color.red;
        LineDrawer = GetComponent<LineRenderer>();
        LineDrawer.material = new Material(Shader.Find("Sprites/Default"));
        LineDrawer.startColor = startColor;
        LineDrawer.endColor = endColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {

        }

        if(isBuildState)
            DrawCircle();
        else
            LineDrawer.positionCount = 0;

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

    public void setMine(GameObject obj)
    {
        float distance = Vector2.Distance(transform.position, obj.transform.position);

        if(distance < 1.75f && mineRoad == null)
        {
            MineScript mineScript = obj.GetComponent(typeof(MineScript)) as MineScript;
            mine = mineScript;
            GameObject newMineRoad = Instantiate(road, transform.position, Quaternion.identity);
            Vector2 rotationVector = new Vector2(
               transform.position.x - obj.transform.position.x,
                transform.position.y - obj.transform.position.y
            );
            newMineRoad.transform.localScale += new Vector3(0, distance, 1);
            newMineRoad.transform.up = rotationVector;

            Vector3 roadPos = new Vector3(
                (obj.transform.position.x + transform.position.x) / 2,
                (obj.transform.position.y + transform.position.y) / 2,
                15f
            );
            newMineRoad.transform.position = roadPos;

            RoadScript roadScript = newMineRoad.GetComponent(typeof(RoadScript)) as RoadScript;
            // Set Road variables
            roadScript.setTopObject(obj); // top object the builded object
            //roadScript.setBottomObject(this); //  bottom object platform
            mineRoad = roadScript;
        }
    }

    public void setBuildStateActive(bool newState)
    {
        isBuildState = newState;
    }
    public bool getBuildStateActive()
    {
        return isBuildState;
    }
    public bool isSelected()
    {
        return active;
    }

    public void setSelect(bool boolean)
    {
        active = boolean;
    }

}
