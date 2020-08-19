using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineInternal;

public class Manager : MonoBehaviour
{
    private GameObject activeObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(pos, Camera.main.transform.forward);

            if (activeObject != null)
            {
                
                SpriteRenderer spriteRenderer = activeObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
                spriteRenderer.color = Color.red;
            }

            if (hit.collider != null)
            {
               
                if (hit.collider.tag == "Platform")
                {
                    Debug.Log("this is Platform=");
                    activeObject = hit.collider.gameObject;
                    SpriteRenderer spriteRenderer = activeObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
                    spriteRenderer.color = Color.black;
                }
                if (hit.collider.tag == "Factory")
                {
                    Debug.Log("this is Factory");
                }
            }
            else
            {
                SpriteRenderer spriteRenderer = activeObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
                spriteRenderer.color = Color.red;
                activeObject = null;
            }
        }
    }
}
