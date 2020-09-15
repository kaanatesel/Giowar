using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngineInternal;

public class Manager : MonoBehaviour
{
    //Public Variables
    public GameObject resourceManager;
    public Button endBuildSate;
    public Button buildBtn;
    public Button WorkerBtn;
    public Text BuildStateText;
    public GameObject buildPanel;
    public GameObject willBuildObject;
    public GameObject road;
    public List<MinaralScript> resourceList;
    //Private Variables
    private GameObject activeObject;
    private bool buildStateActive;
    private ResourceManagerScript resourceManagerScript;
    private float cameraMoveSpeed;
    private float zoomOutMin = 2;
    private float zoomOutMax = 30;
    private List<TowerScript> towerScripts;
    // Resource production Variables
    private int goldIncomePerMine;
    private int minaralIncomePerMine;
    private float goldIncomeSec;
    private float minaralIncomeSec;
    // Touch Variable
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance; // how much does the player moved his finger    


    void Awake()
    {
        resourceManagerScript = resourceManager.GetComponent(typeof(ResourceManagerScript)) as ResourceManagerScript;
        goldIncomePerMine = 1;
        minaralIncomePerMine = 1;
        goldIncomeSec = 5.0f;
        minaralIncomeSec = 3.0f;
        cameraMoveSpeed = 10;
    }
    void Start()
    {
        activeObject = null;
        buildStateActive = false;
        InvokeRepeating("updateGold", goldIncomeSec, 7.0f);
        InvokeRepeating("updateMinaral", minaralIncomeSec, 7.0f);
        dragDistance = 0.05f;
    }

    //Update is called once per frame
    void Update()
    {
        if (activeObject != null && activeObject.tag == "Platform")
        {
            buildBtn.interactable = true;
            WorkerBtn.interactable = false;
        }
        else if (activeObject != null && activeObject.tag == "House")
        {
            WorkerBtn.interactable = true;
            buildBtn.interactable = false;
        }
        else
        {
            buildBtn.interactable = false;
            WorkerBtn.interactable = false;
        }

        if (buildStateActive)
        {
            buildBtn.gameObject.SetActive(false);
            endBuildSate.gameObject.SetActive(true);
            BuildStateText.gameObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if(Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;            
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

            float prevMagnitude = (touch0PrevPos - touch1PrevPos).magnitude;
            float curMagnitude = (touch0.position - touch1.position).magnitude;

            float distance = curMagnitude - prevMagnitude;
            float moveDist = distance * 0.01f;
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - moveDist, zoomOutMin, zoomOutMax);
        }
        else if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(pos, Camera.main.transform.forward);

            if (buildStateActive)
            {
                float distance = Vector3.Distance(activeObject.transform.position, pos);
                PlatformScript platformScript = activeObject.GetComponent(typeof(PlatformScript)) as PlatformScript;
                /*Debug.Log(distance);
                  Debug.Log(activeObject.transform.position);
                  Debug.Log(pos);*/
                if (touch.phase == TouchPhase.Began
                   && willBuildObject != null
                   && touch.position.y > 30
                   && hit.collider == null
                   && distance <= 1.75f
                   && platformScript != null
                   && platformScript.canHaveMoreRoad()
                   )
                {
                    IBuyAble buyAble = willBuildObject.GetComponent(typeof(IBuyAble)) as IBuyAble;
                    if (buyAble != null && resourceManagerScript.canBuy(buyAble.getGoldPrice(), buyAble.getMinaralPrice()))
                    {
                        GameObject newObj = Instantiate(willBuildObject, pos, Quaternion.identity);
                        IcanHaveRoad haveRoad = newObj.GetComponent(typeof(IcanHaveRoad)) as IcanHaveRoad;
                        // rotate new object face to the platform
                        Vector2 rotationVector = new Vector2(
                                activeObject.transform.position.x - newObj.transform.position.x,
                                activeObject.transform.position.y - newObj.transform.position.y
                            );
                        newObj.transform.up = rotationVector;
                        // Create road
                        GameObject connetionRoad = Instantiate(road, activeObject.transform.position, Quaternion.identity);
                        // rotate and scale the road between newObj and platform
                        connetionRoad.transform.localScale += new Vector3(0, distance, 1);
                        connetionRoad.transform.up = rotationVector;
                        Vector3 roadPos = new Vector3(
                            (newObj.transform.position.x + activeObject.transform.position.x) / 2,
                            (newObj.transform.position.y + activeObject.transform.position.y) / 2,
                            15f
                            );
                        connetionRoad.transform.position = roadPos;
                        RoadScript roadScript = connetionRoad.GetComponent(typeof(RoadScript)) as RoadScript;
                        // Set Road variables
                        roadScript.setTopObject(newObj); // top object the builded object
                        roadScript.setBottomObject(activeObject); //  bottom object platform
                                                                  // Add road to new builded object
                        haveRoad.addRoad(roadScript);
                        // Adding roads to platformObject
                        platformScript.addRoad(roadScript);

                        if (newObj.CompareTag("Mine"))
                        {
                            checkMineAndMinaralConnetion(newObj);
                        }
                        if (newObj.CompareTag("House"))
                        {
                            resourceManagerScript.updateMaxPopulationCount(5);
                        }

                        // Buy the building
                        resourceManagerScript.buyBuilding(buyAble.getGoldPrice(), buyAble.getMinaralPrice());
                    }
                    else
                    {
                        Debug.Log("you cant buy");
                    }
                }
                endBuildingState();
            }
            else if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = Camera.main.ScreenToWorldPoint(touch.position);
                lp = Camera.main.ScreenToWorldPoint(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = Camera.main.ScreenToWorldPoint(touch.position);
                Vector3 camMovePos = lp - fp;
                Camera.main.transform.position += -camMovePos * Time.deltaTime * cameraMoveSpeed;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = Camera.main.ScreenToWorldPoint(touch.position);
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {
                    Vector3 camMovePos = lp - fp;
                    Camera.main.transform.position += -camMovePos * Time.deltaTime * cameraMoveSpeed;
                }
                else
                {
                    if (EventSystem.current.IsPointerOverGameObject() && buildPanel.activeSelf)
                    {
                        Debug.Log("on game object");
                    }
                    else
                    {
                        if (buildPanel.activeSelf)
                        {
                            buildPanel.SetActive(false);
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
        closeMinaralCircle();
    }

    public GameObject getActiveObject()
    {
        return activeObject;
    }

    public void openMinaralCircle()
    {
        if (resourceList.Count > 0)
        {
            foreach (MinaralScript ms in resourceList)
                ms.setBuildStateActive(true);
        }
    }
    public void closeMinaralCircle()
    {
        if (resourceList.Count > 0)
        {
            foreach (MinaralScript ms in resourceList)
                ms.setBuildStateActive(false);
        }
    }
    public void checkMineAndMinaralConnetion(GameObject obj)
    {
        if (resourceList.Count > 0)
        {
            foreach (MinaralScript ms in resourceList)
                ms.setMine(obj);
        }
    }

    public void updateMinaral()
    {
        int activeMinaralCount = 0;
        if(resourceList.Count > 0)
        {
            foreach (MinaralScript ms in resourceList)
                if (ms.isBeingDig() && ms.gameObject.CompareTag("minaralMine"))
                    activeMinaralCount += 1;
        }

        resourceManagerScript.updateMinaralCount(activeMinaralCount * minaralIncomePerMine);
    }

    public void updateGold()
    {
        // Active Mine Count
        int activeMineCount = 0;
        if (resourceList.Count > 0)
        {
            foreach (MinaralScript ms in resourceList)
                if (ms.isBeingDig() && ms.gameObject.CompareTag("goldMine"))
                    activeMineCount += 1;
        }

        // Update Resource
        resourceManagerScript.updateGoldCount(activeMineCount * goldIncomePerMine);
    }
}
