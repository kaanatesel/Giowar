using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaralMineRoad : RoadScript
{
    //Public Variables
    public GameObject miner;
    //Private Variables

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GenerateMiner()
    {
        GameObject newMiner = Instantiate(miner, getTopObject().transform.position, Quaternion.identity);
        MinerScript minerSc = newMiner.GetComponent(typeof(MinerScript)) as MinerScript;
        minerSc.setDirection(getBottomObject().transform.position);
        RoadScript roadSc = GetComponent(typeof(RoadScript)) as RoadScript;
        minerSc.setRoadMovingOn(roadSc);
    }

    IEnumerator waitEndCreateMiner()
    {
        yield return new WaitForSeconds(2);
        GenerateMiner();

        yield return new WaitForSeconds(2);
        GenerateMiner();
    }
    
    public void connetedToMine()
    {
        StartCoroutine(waitEndCreateMiner());
    }
}
