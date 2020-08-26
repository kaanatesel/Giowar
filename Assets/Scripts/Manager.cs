using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngineInternal;

public class Manager : MonoBehaviour
{
    //Public Variables
    public Button buildBtn;
    public GameObject buildPanel;
    public GameObject willBuildObject;
    //Private Variables
    private GameObject activeObject = null;
    private bool buildStateActive = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeObject != null && activeObject.tag == "Platform")
        {
            buildBtn.interactable = true;
        }
        else
        {
            buildBtn.interactable = false;
        }
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(pos, Camera.main.transform.forward);

            if(EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("on game object");
            }
            else
            {
                if (buildPanel.activeSelf)
                {
                    buildPanel.SetActive(false);
                }
                else if(buildStateActive)
                {
                    
                    if (Input.touchCount > 0)
                    {
                        float distance = Vector2.Distance(activeObject.transform.position, touch.position);
                        Debug.Log(distance);
                        if (touch.phase == TouchPhase.Began
                           && willBuildObject != null
                           && touch.position.y > 30
                           && hit.collider == null
                           && distance <= 330
                           )
                        {
                            Instantiate(willBuildObject, pos, Quaternion.identity);
                        }
                        buildStateActive = false;
                    }
                }
                else {
                    if (touch.position.y > 30)
                    {
                        if (hit.collider != null)
                        {
                            if (activeObject != null)
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
                            if (activeObject != null)
                            {
                                IselectAble platform = activeObject.GetComponent(typeof(IselectAble)) as IselectAble;
                                platform.setSelect(false);
                                activeObject = null;
                            }
                        }
                    }
                    else
                    {
                        // menu element
                    }
                }
            }
        }
    }

    public void setBuildState(bool boolean)
    {
        buildStateActive = boolean;
    }

    public bool isBuildStateActive()
    {
        return buildStateActive;
    }

    public void endBuildingState()
    {
        setBuildState(false);
    }
}
