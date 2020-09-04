using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{

    //Private Variables
    private Vector3 position;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public Vector3 getPosition()
    {
        return transform.position;
    }
}
