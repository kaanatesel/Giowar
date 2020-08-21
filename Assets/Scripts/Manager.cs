using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineInternal;

public class Manager : MonoBehaviour
{
    private GameObject activeObject = null;
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

            
            if (hit.collider != null)
            {
                if(activeObject != null)
                {
                    IselectAble tmp = activeObject.GetComponent(typeof(IselectAble)) as IselectAble;
                    tmp.setSelect(false);
                    activeObject = hit.collider.gameObject;
                    IselectAble selectedObject = activeObject.GetComponent(typeof(IselectAble)) as IselectAble;
                    selectedObject.setSelect(true);
                }
                else
                {
                    activeObject = hit.collider.gameObject;
                    IselectAble selectedObject = activeObject.GetComponent(typeof(IselectAble)) as IselectAble;
                    selectedObject.setSelect(true);
                }
            }
            else
            {
                if(activeObject != null)
                {
                    IselectAble platform = activeObject.GetComponent(typeof(IselectAble)) as IselectAble;
                    platform.setSelect(false);
                    activeObject = null;
                }
            }
        }
    }
}
