using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public Manager manager;
    public GameObject Worker;
    public void openBuildPanel()
    {
        manager.buildPanel.SetActive(true);
    }
    public void closeBuildPanel()
    {
        manager.buildPanel.SetActive(false);
    }
    public void setWillBuildObject(GameObject obj)
    {
        manager.willBuildObject = obj;
        manager.setBuildState(true);
        manager.buildPanel.SetActive(false);
        if (obj.tag == "Mine")
        {
            manager.openMinaralCircle();
        }
    }

    
    public void endBuildingState()
    {
        manager.endBuildingState();
    }

    public void createWorker()
    {
        GameObject activeObj = manager.getActiveObject();
        IcanHaveRoad haveRoad = activeObj.GetComponent(typeof(IcanHaveRoad)) as IcanHaveRoad;
        RoadScript roadScript = haveRoad.getRoad();
        GameObject newWorker = Instantiate(Worker, roadScript.getTopObject().transform.position, Quaternion.identity);
        WorkerScript worker = newWorker.GetComponent(typeof(WorkerScript)) as WorkerScript;
        worker.setDirection(roadScript.getBottomObject().transform.position);
        worker.setRoadMovingOn(roadScript);


    }
}
