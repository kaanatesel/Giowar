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
    }
    
    public void endBuildingState()
    {
        manager.endBuildingState();
    }

    public void createWorker()
    {
        GameObject activeObj = manager.getActiveObject();
        IcanHaveRoad haveRoad = activeObj.GetComponent(typeof(IcanHaveRoad)) as IcanHaveRoad;
        Vector3 summonPostion = new Vector3(activeObj.transform.position.x, activeObj.transform.position.y, 0);
        GameObject newWorker = Instantiate(Worker, summonPostion, Quaternion.identity);
        ImoveAble worker = newWorker.GetComponent(typeof(ImoveAble)) as ImoveAble;

        Vector3 directionVector = new Vector3(
            (haveRoad.getRoad().getPosition().x)*2 - activeObj.transform.position.x,
            (haveRoad.getRoad().getPosition().y)*2 - activeObj.transform.position.y,
            0
            );

        worker.setDirection(directionVector);
    }
}
