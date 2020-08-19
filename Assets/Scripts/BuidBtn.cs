using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuidBtnScript : MonoBehaviour
{
    public GameObject buildPanel;
    public void openBuildPanel()
    {
        Debug.Log("clicked amk");
        buildPanel.SetActive(true);
    }
}
