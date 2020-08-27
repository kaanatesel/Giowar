using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryScript : MonoBehaviour , IselectAble
{
    // Public Variables
    // Private Varibales
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
            Debug.Log("FACROY IS ACTIVE");
    }
    public bool isSelected()
    {
        return active;
    }

    public void setSelect(bool boolean)
    {
        active = boolean;
    }
}
