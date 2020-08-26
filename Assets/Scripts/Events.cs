using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public Manager manager;
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
}
