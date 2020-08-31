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
    public Button endBuildSate;
    public Button buildBtn;
    public Text BuildStateText;
    public GameObject buildPanel;
    public GameObject willBuildObject;
    public GameObject road;
    //Private Variables
    private GameObject activeObject;
    private bool buildStateActive;
    void Start()
    {
        activeObject = null;
        buildStateActive = false;
    }

    //Update is called once per frame
    void Update()
    {
        if (activeObject != null && activeObject.tag == "Platform")
            buildBtn.interactable = true;
        else
            buildBtn.interactable = false;

        if (buildStateActive)
        {
            buildBtn.gameObject.SetActive(false);
            endBuildSate.gameObject.SetActive(true);
            BuildStateText.gameObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(pos, Camera.main.transform.forward);

            if (EventSystem.current.IsPointerOverGameObject() && buildPanel.activeSelf)
            {
                Debug.Log("on game object");
            }
            else
            {
                if(buildPanel.activeSelf)
                {
                    buildPanel.SetActive(false);
                }
                else if (buildStateActive)
                {
                    float distance = Vector3.Distance(activeObject.transform.position, pos);
/*                    Debug.Log(distance);
                    Debug.Log(activeObject.transform.position);
                    Debug.Log(pos);*/
                    if (touch.phase == TouchPhase.Began
                       && willBuildObject != null
                       && touch.position.y > 30
                       && hit.collider == null
                       && distance <= 1.75f
                       )
                    {
                        GameObject newObj = Instantiate(willBuildObject, pos, Quaternion.identity);
                        Vector2 rotationVector = new Vector2(
                                activeObject.transform.position.x - newObj.transform.position.x,
                                activeObject.transform.position.y - newObj.transform.position.y
                            );
                        newObj.transform.up = rotationVector;
                        GameObject connetionRoad = Instantiate(road, activeObject.transform.position, Quaternion.identity);
                        connetionRoad.transform.localScale += new Vector3(0, distance, 1);
                        connetionRoad.transform.up = rotationVector;
                        Vector3 roadPos = new Vector3(
                            (newObj.transform.position.x + activeObject.transform.position.x) / 2,
                            (newObj.transform.position.y + activeObject.transform.position.y) / 2,
                            15f
                            );
                        connetionRoad.transform.position = roadPos;
                    }
                    endBuildingState();
                }
                else
                {
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
                                if (platform != null)
                                {
                                    platform.setSelect(false);
                                    activeObject = null;
                                }
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
        if(activeObject != null)
        {
            IselectAble selected = activeObject.GetComponent(typeof(IselectAble)) as IselectAble;
            selected.setSelect(false);
            activeObject = null;
        }
        buildBtn.gameObject.SetActive(true);
        setBuildState(false);
        endBuildSate.gameObject.SetActive(false);
        BuildStateText.gameObject.SetActive(false);
    }
}
