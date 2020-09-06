using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerScript : WorkerScript
{
    //Public Variables
    //Private Variables
    private Vector3 minaralPosition;
    private Vector3 minePosition;
    void Awake()
    {
        speed = 2;

    }
    // Start is called before the first frame update
    void Start()
    {
        minePosition = roadMovingOn.getTopObject().transform.position;
        minaralPosition = roadMovingOn.getBottomObject().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveDirection == transform.position)
        {
            if (transform.position == minePosition)
                moveDirection = minaralPosition;
            else
                moveDirection = minePosition;
        }
        else
        {
            move();
        }
    }
}
