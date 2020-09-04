using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerScript : MonoBehaviour, ImoveAble
{

    // Private Variables
    private Vector3 moveDirection = new Vector3();
    private float speed;
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
            Collider[] hitColliders = Physics.OverlapSphere(transform.position,0.1f);
            foreach(Collider colied in hitColliders)
            {
                Debug.Log(colied.gameObject);
            }
        }
        
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
