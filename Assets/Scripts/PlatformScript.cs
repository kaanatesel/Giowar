using Assets.Scripts;
using UnityEngine;

public class PlatformScript : MonoBehaviour, IselectAble
{
    public GameObject itSelf;

    private const float radius = 60f;
    private bool acvtive = false;
    private Color color;
    
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = itSelf.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        color = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (acvtive)
        {
            Debug.Log("plat is active");
            SpriteRenderer spriteRenderer = itSelf.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
            spriteRenderer.color = Color.black;
        }
        else
        {
            SpriteRenderer spriteRenderer = itSelf.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
            spriteRenderer.color = color;
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
