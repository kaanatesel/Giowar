using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{

    //Private Variables
    private Vector3 position;
    private GameObject topObject;
    private GameObject bottomObject;

    // Start is called before the first frame update
    void Start()
    {
    }

    public Vector3 getPosition()
    {
        return transform.position;
    }

    public GameObject getTopObject()
    {
        return topObject;
    }
    public void setTopObject(GameObject topObj)
    {
        topObject = topObj;
    }
    public GameObject getBottomObject()
    {
        return bottomObject;
    }
    public void setBottomObject(GameObject bottomObj)
    {
        bottomObject = bottomObj;
    }
}
