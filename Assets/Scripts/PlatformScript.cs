using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class PlatformScript : MonoBehaviour, IselectAble
{
    //Public Variables
    public GameObject itSelf;
    //Private Variables
    private bool acvtive;
    private Color color;
    //Draw Circle variables
    public float ThetaScale = 0.001f;
    public float radius = 2f;
    private int Size;
    private LineRenderer LineDrawer;
    private float Theta = 0f;
    private Color startColor, endColor;

    

    // Start is called before the first frame update
    void Start()
    {
        acvtive = false;    
        SpriteRenderer spriteRenderer = itSelf.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        color = spriteRenderer.color;
        startColor = Color.green;
        endColor = Color.black;
        LineDrawer = GetComponent<LineRenderer>();
        LineDrawer.material = new Material(Shader.Find("Sprites/Default"));
        LineDrawer.SetColors(startColor, endColor);
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer spriteRenderer = itSelf.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        
        if (acvtive)
        {
            spriteRenderer.color = Color.black;
            DrawCircle();
        }
        else
        {
            spriteRenderer.color = color;
            LineDrawer.positionCount = 0;
        }
    }
    
    private void DrawCircle()
    {
        Theta = 0f;
        Size = (int)((1f / ThetaScale) + 2f);
        LineDrawer.SetVertexCount(Size);
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

}
