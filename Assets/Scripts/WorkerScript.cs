using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerScript : MonoBehaviour, ImoveAble
{

    // Private Variables
    private Vector3 moveDirection = new Vector3();
    private float speed;
    private RoadScript roadMovingOn;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveDirection != transform.position)
        {
            move();
        }
        else
        {
            if (transform.position == roadMovingOn.getBottomObject().transform.position)
            {
                IcanHaveRoad haveRoad = roadMovingOn.getBottomObject().GetComponent(typeof(IcanHaveRoad)) as IcanHaveRoad;
                RoadScript newRoad = haveRoad.getRoad();
                roadMovingOn = newRoad;
                if (moveDirection != newRoad.getTopObject().transform.position)
                    moveDirection = newRoad.getTopObject().transform.position;
                else
                    moveDirection = haveRoad.getRoad().getBottomObject().transform.position;
            }
            else
            {
                IcanHaveRoad haveRoad = roadMovingOn.getTopObject().GetComponent(typeof(IcanHaveRoad)) as IcanHaveRoad;
                RoadScript newRoad = haveRoad.getRoad();
                roadMovingOn = newRoad;
                if (moveDirection != newRoad.getBottomObject().transform.position)
                    moveDirection = newRoad.getBottomObject().transform.position;
                else
                    moveDirection = newRoad.getTopObject().transform.position;
                    
            }
        }
    }

    public RoadScript getRoadMovingOn()
    {
        return roadMovingOn;
    }
    public void setRoadMovingOn(RoadScript theRoad)
    {
        roadMovingOn = theRoad;
    }
    public void setDirection(Vector3 dirVec)
    {
        moveDirection = dirVec;
    }

    public Vector3 getMovingDirection()
    {
        return moveDirection;
    }

    public void move()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, moveDirection, step);
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public float getSpeed()
    {
        return speed;
    }
}
